using System;
using System.Collections.Generic;
using System.Text;
using Avalonia;
using Avalonia.Controls;
using OptsLib.Builders;

// ReSharper disable once CheckNamespace
namespace OptsLib
{
    public static class AppBuilderExtensions
    {
        public static TAppBuilder UseOptions<TOptions, TAppBuilder>(this TAppBuilder builder, Func<IOptionsManagerBuilder<TOptions>> configureManager)
            where TAppBuilder : AppBuilderBase<TAppBuilder>, new() where TOptions :class, IOptions, new()
        {
            var manager = configureManager().Build();

            AvaloniaLocator.CurrentMutable.Bind<OptionsManager<TOptions>>().ToConstant(manager);

            return builder;
        }

    }
}
