using Autofac;
using Autofac.Core;
using Autofac.Core.Registration;
using MyJetWallet.Sdk.NoSql;
using Service.Liquidity.InternalWallets.Domain.Models;
using Service.Liquidity.InternalWallets.Services;

namespace Service.Liquidity.InternalWallets.Modules
{
    public class ServiceModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<LpWalletManager>()
                .As<ILpWalletManager>()
                .As<IStartable>()
                .AutoActivate()
                .SingleInstance();
            
            builder.RegisterMyNoSqlWriter<LpWalletNoSql>(Program.ReloadedSettings(e => e.MyNoSqlWriterUrl), LpWalletNoSql.TableName);
        }
    }
}