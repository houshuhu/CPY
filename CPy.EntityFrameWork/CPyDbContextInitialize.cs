using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using CPy.Model.FluentAPI;

namespace CPy.EntityFrameWork
{
    public class CPyDbContextInitialize
    {
        /// <summary>
        /// 数据库生成策略：自动迁移至最新版本，具体配置请看<see cref="Migrations.Configuration"/>
        /// </summary>
        public static void Initialization()
        {
            //自动迁移
            Database.SetInitializer<CPyDbContext>(new MigrateDatabaseToLatestVersion<CPyDbContext,Migrations.Configuration>());
            var dbMigrator = new DbMigrator(new Migrations.Configuration());
            dbMigrator.Update();
        }
    }
}