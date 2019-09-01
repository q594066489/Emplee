





using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;
using Abp;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Configuration;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Emploee.Approvals.Authorization;
using Emploee.Approvals.Dtos;
using Emploee.Dto;
using Emploee.Emploees.Companies;

#region 代码生成器相关信息_ABP Code Generator Info
//你好，我是ABP代码生成器的作者,欢迎您使用该工具，目前接受付费定制该工具，有需要的可以联系我
//我的邮箱:werltm@hotmail.com
// 官方网站:"http://www.yoyocms.com"
// 交流QQ群：104390185  
//微信公众号：角落的白板报
// 演示地址:"vue版本：http://vue.yoyocms.com angularJs版本:ng1.yoyocms.com"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>梁桐铭 ,微软MVP</Author-作者>
// Copyright © YoYoCms@China.2019-07-25T10:30:56. All Rights Reserved.
//<生成时间>2019-07-25T10:30:56</生成时间>
#endregion


namespace Emploee.Approvals
{
    /// <summary>
    /// 企业注册审批服务实现
    /// </summary>
    [AbpAuthorize(ApprovalAppPermissions.Approval)]


    public class ApprovalAppService : EmploeeAppServiceBase, IApprovalAppService
    {
        private readonly IRepository<Approval, int> _approvalRepository;
        private readonly IApprovalListExcelExporter _approvalListExcelExporter;
        private readonly IRepository<Company, int> _companyRepository;

        private readonly ApprovalManage _approvalManage;
        /// <summary>
        /// 构造方法
        /// </summary>
        public ApprovalAppService(
            IRepository<Approval, int> approvalRepository,
            ApprovalManage approvalManage,
            IApprovalListExcelExporter approvalListExcelExporter,
            IRepository<Company, int> companyRepository
  )
        {
            _approvalRepository = approvalRepository;
            _approvalManage = approvalManage;
            _approvalListExcelExporter = approvalListExcelExporter;
            _companyRepository = companyRepository;
        }


        #region 实体的自定义扩展方法
        private IQueryable<Approval> _approvalRepositoryAsNoTrack => _approvalRepository.GetAll().AsNoTracking();


        #endregion


        #region 企业注册审批管理

        /// <summary>
        /// 根据查询条件获取企业注册审批分页列表
        /// </summary>
        public async Task<PagedResultDto<ApprovalListDto>> GetPagedApprovalsAsync(GetApprovalInput input)
        {
            
            //var dormitory_DormChecks = await query.OrderByDescending(t => t.CheckTime).ThenBy(t => t.Building).ThenBy(t => t.DoorNum).ThenBy(t => t.BedNum).Skip(input.SkipCount).Take(input.MaxResultCount)
            //.ToListAsync();


            //return new PagedResultDto<Dormitory_DormCheckListDto>(
            //dormitory_DormCheckCount,
            //dormitory_DormChecks.Select(
            //    item =>
            //    {
            //        var dto = new Dormitory_DormCheckListDto();
            //        dto.Id = item.Id;
            //        dto.Building = item.Building;
            //        dto.DoorNum = item.DoorNum;
            //        dto.BedNum = item.BedNum;
            //        dto.IDcard = item.IDcard;
            //        dto.PersonName = item.PersonName;
            //        dto.CheckTime = item.CheckTime;
            //        dto.CheckType = item.CheckType;
            //        dto.CheckReason = item.CheckReason;
            //        dto.Company = item.Company.IsNullOrEmpty() ? "" : item.Company;
            //        dto.Department = item.Department.IsNullOrEmpty() ? "" : item.Department;
            //        dto.Gongduan = item.Gongduan.IsNullOrEmpty() ? "" : item.Gongduan;
            //        dto.AgainstType = item.AgainstType;
            //        dto.ShouldPay = item.ShouldPay;
            //        dto.Phone = item.Phone.IsNullOrEmpty() ? "" : item.Phone;

            //        return dto;

            //    }).ToList()
            //);
            //var query = _approvalRepositoryAsNoTrack; _companyRepository

            var query = from approval in _approvalRepositoryAsNoTrack
                        join company in _companyRepository.GetAll().AsNoTracking()
                        on approval.CompanyID  equals company.CompanyID
                        
                        select new
                        {
                            approval,
                            company.CompanyName
                        };
            //TODO:根据传入的参数添加过滤条件

            var approvalCount = await query.CountAsync();

            //var approvals = await query
            //.OrderBy(input.Sorting)
            //.PageBy(input)
            //.ToListAsync();
            var approvals = await query
            .OrderBy(t=>t.approval.Id).Skip(input.SkipCount).Take(input.MaxResultCount).ToListAsync();
            //var dormitory_DormChecks = await query.OrderByDescending(t => t.CheckTime).ThenBy(t => t.Building).ThenBy(t => t.DoorNum).ThenBy(t => t.BedNum).Skip(input.SkipCount).Take(input.MaxResultCount)
            //.ToListAsync();
            // 
            return new PagedResultDto<ApprovalListDto>(
            approvalCount,
            //approvalListDtos
            approvals.Select(
                item =>
                {
                    var dto = new ApprovalListDto();
                    dto.Id = item.approval.Id;
                    dto.CompanyID = item.approval.CompanyID;
                    dto.CompanyName = item.CompanyName;
                    dto.RegisterDate = item.approval.RegisterDate;
                    dto.IsPay = item.approval.IsPay;
                    dto.PayAmount = item.approval.PayAmount;
                    dto.PayTime = item.approval.PayTime;
                    dto.CoopTime = item.approval.CoopTime;
                    dto.Weight = item.approval.Weight;
                    dto.CreationTime = item.approval.CreationTime;

                    return dto;

                }).ToList()
            );
        }

        /// <summary>
        /// 通过Id获取企业注册审批信息进行编辑或修改 
        /// </summary>
        public async Task<GetApprovalForEditOutput> GetApprovalForEditAsync(NullableIdDto<int> input)
        {
            var output = new GetApprovalForEditOutput();

            ApprovalEditDto approvalEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _approvalRepository.GetAsync(input.Id.Value);
                approvalEditDto = entity.MapTo<ApprovalEditDto>();
            }
            else
            {
                approvalEditDto = new ApprovalEditDto();
            }

            output.Approval = approvalEditDto;
            return output;
        }


        /// <summary>
        /// 通过指定id获取企业注册审批ListDto信息
        /// </summary>
        public async Task<ApprovalListDto> GetApprovalByIdAsync(EntityDto<int> input)
        {
            var entity = await _approvalRepository.GetAsync(input.Id);

            return entity.MapTo<ApprovalListDto>();
        }







        /// <summary>
        /// 新增或更改企业注册审批
        /// </summary>
        public async Task CreateOrUpdateApprovalAsync(CreateOrUpdateApprovalInput input)
        {
            if (input.ApprovalEditDto.Id.HasValue)
            {
                await UpdateApprovalAsync(input.ApprovalEditDto);
            }
            else
            {
                await CreateApprovalAsync(input.ApprovalEditDto);
            }
        }

        /// <summary>
        /// 新增企业注册审批
        /// </summary>
        [AbpAuthorize(ApprovalAppPermissions.Approval_CreateApproval)]
        public virtual async Task<ApprovalEditDto> CreateApprovalAsync(ApprovalEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = input.MapTo<Approval>();

            entity = await _approvalRepository.InsertAsync(entity);
            return entity.MapTo<ApprovalEditDto>();
        }

        /// <summary>
        /// 编辑企业注册审批
        /// </summary>
        [AbpAuthorize(ApprovalAppPermissions.Approval_EditApproval)]
        public virtual async Task UpdateApprovalAsync(ApprovalEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _approvalRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            await _approvalRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除企业注册审批
        /// </summary>
        [AbpAuthorize(ApprovalAppPermissions.Approval_DeleteApproval)]
        public async Task DeleteApprovalAsync(EntityDto<int> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _approvalRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除企业注册审批
        /// </summary>
        [AbpAuthorize(ApprovalAppPermissions.Approval_DeleteApproval)]
        public async Task BatchDeleteApprovalAsync(List<int> input)
        {
            //TODO:批量删除前的逻辑判断，是否允许删除
            await _approvalRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        #endregion
        #region 企业注册审批的Excel导出功能


        public async Task<FileDto> GetApprovalToExcel()
        {
            var entities = await _approvalRepository.GetAll().ToListAsync();

            var dtos = entities.MapTo<List<ApprovalListDto>>();

            var fileDto = _approvalListExcelExporter.ExportApprovalToFile(dtos);



            return fileDto;
        }


        #endregion










    }
}
