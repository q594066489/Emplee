namespace Emploee
{
    /// <summary>
    /// Some general constants for the application.
    /// </summary>
    public class EmploeeConsts
    {
        public const string LocalizationSourceName = "Emploee";

        public const bool MultiTenancyEnabled = true;
        /// <summary>
        /// 显示名称的最大长度
        /// </summary>
        public const int MaxDisplayNameLength = 64;

        /// <summary>
        /// 用户名的最大长度
        /// </summary>
        public const int MaxUserNameLength = 32;

        /// <summary>
        /// 分页
        /// </summary>
        public const int MaxPageSize = 1000;
        /// <summary>
        /// 分页
        /// </summary>
        public const int DefaultPageSize = 10;

        /// <summary>
        /// 数据库架构名
        /// </summary>
        public static class SchemaName
        {
            /// <summary>
            /// 基础设置
            /// </summary>
            public const string Basic = "";

            /// <summary>
            /// 模块管理
            /// </summary>
            public const string Moudle = "Moudle";

            /// <summary>
            /// 网站设置
            /// </summary>
            public const string WebSetting = "WebSetting";
            /// <summary>
            /// 用于对多对表关系的结构
            /// </summary>
            public const string HasMany = "HasMany";

            /// <summary>
            /// 业务
            /// </summary>
            public const string Business = "Business";

        }
    }
}