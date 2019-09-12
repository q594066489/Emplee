





using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Abp;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Collections.Extensions;
using Abp.Configuration;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Castle.Core.Internal;
using Emploee.Approvals.Authorization;
using Emploee.Approvals.Dtos;
using Emploee.Dto;
using Emploee.Emploees.Companies;
using Emploee.PayLogs;
using Z.EntityFramework.Plus;

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
        private readonly IRepository<PayLog, int> _paylogRepository;
        private readonly ApprovalManage _approvalManage;
        /// <summary>
        /// 构造方法
        /// </summary>
        public ApprovalAppService(
            IRepository<Approval, int> approvalRepository,
            ApprovalManage approvalManage,
            IApprovalListExcelExporter approvalListExcelExporter,
            IRepository<Company, int> companyRepository,
            IRepository<PayLog, int> paylogRepository
  )
        {
            _approvalRepository = approvalRepository;
            _approvalManage = approvalManage;
            _approvalListExcelExporter = approvalListExcelExporter;
            _companyRepository = companyRepository;
            _paylogRepository=paylogRepository;
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
           
            var query = (from approval in _approvalRepositoryAsNoTrack
                        join company in _companyRepository.GetAll().AsNoTracking()
                        on approval.CompanyID  equals company.CompanyID
                        
                        select new
                        {
                            approval,
                            company.CompanyName
                        }).WhereIf(!string.IsNullOrEmpty(input.FilterText), t => t.CompanyName.Contains(input.FilterText.Trim()))
                        .WhereIf(input.isPay!=null,  t => t.approval.IsPay == input.isPay)
                        .WhereIf(input.isShow!=null,t=>t.approval.IsShow==input.isShow);
            //TODO:根据传入的参数添加过滤条件

            var approvalCount = await query.CountAsync();
             
            var approvals = await query
            .OrderByDescending(t=>t.approval.RegisterDate).Skip(input.SkipCount).Take(input.MaxResultCount).ToListAsync();
             
            return new PagedResultDto<ApprovalListDto>(
            approvalCount,
             
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
                    dto.isShow = item.approval.IsShow;
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
                var companyname =  _companyRepository.FirstOrDefault(t=>t.CompanyID==entity.CompanyID).CompanyName;
                
                approvalEditDto = entity.MapTo<ApprovalEditDto>();
                approvalEditDto.CompanyName = companyname;
            }
            else
            {
                approvalEditDto = new ApprovalEditDto();
            }
            approvalEditDto.PayTime = DateTime.Now;
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
                return ;
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
            if (entity == null)
            {
                return ;
            }
            Approval _approval =input.MapTo(entity);
            _approval.IsPay = true;
            _approval.IsShow = true;
            await _approvalRepository.UpdateAsync(entity);
            PayLog _payLog = new PayLog();
            _payLog.CompanyID = _approval.CompanyID;
            _payLog.CoopTime =Convert.ToInt32( _approval.CoopTime);
            _payLog.PayAmount= Convert.ToInt32(_approval.PayAmount);
            _payLog.PayTime = Convert.ToDateTime(_approval.PayTime);
            await _paylogRepository.InsertAsync(_payLog);
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

        public async Task BatchChangeState(string input,bool isShow)
        {
            try
            {
                var sss = input;
                string datas = input.Trim(new char[] { '[', ']' });
                List<string> changids = datas.Split(',').ToList();
                _approvalRepository.GetAll()
                    .Where(t => changids.Contains(t.Id.ToString()))
                    .Update(x => new Approval() { IsShow = isShow });
            }
            catch(Exception ex)
            {
               
            }
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
