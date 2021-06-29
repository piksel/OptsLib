using System;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Markup.Xaml;
using OptsLib.Avalonia.Editors;
using OptsLib.Editor;
using ReactiveUI;
using Point = System.Drawing.Point;

namespace OptsLib.Avalonia
{
    public class SettingsEditor : UserControl
    {
        public static readonly DirectProperty<SettingsEditor, IOptionsManager> OptionsManagerProperty =
            AvaloniaProperty.RegisterDirect<SettingsEditor, IOptionsManager>("OptionsManager", 
                e => e.OptionsManager,
                (e, v) => e.OptionsManager = v);
        
        public static readonly DirectProperty<SettingsEditor, string?> SelectedSectionProperty =
            AvaloniaProperty.RegisterDirect<SettingsEditor, string?>(nameof(SelectedSection), 
                e => e.SelectedSection,
                (e, v) => e.SelectedSection = v);
        
        private MetaSettings meta = MetaSettings.Empty;
        private readonly StackPanel options;
        private Task<IOptions> current;
        private IOptionsManager? _optionsManager;
        private string? _selectedSection;

        public string? SelectedSection
        {
            get => _selectedSection;
            set
            {
                _selectedSection = value;
                SettingsManagerOnChanged();
            }
        }

        //
        public IOptionsManager OptionsManager
        {
            get => _optionsManager;
            set
            {
                Debug.WriteLine($"Set OptsMan: {value}");
                if (_optionsManager == value) return;
                _optionsManager = value;
                SettingsManagerOnChanged();

                options.DataContext = _optionsManager.GetOptions().Result;

                //_optionsManager.GetOptions().ToObservable().BindTo(options, o => o.DataContext);

                // DataContext = value.GetOptions().Result;
                //OnPropertyChanged()
            }
        }

        private void SettingsManagerOnChanged()
        {
            options.Children.Clear();
            
            if(_optionsManager is null) return;
            
            meta = new MetaSettings(OptionsManager.SettingsType);
            //Bind(DataContextProperty, OptionsManager.GetOptions().ToObservable());


        
            foreach(var (sectionKey, value) in meta.Sections)
            {
                if (meta.Sections.Count > 1 && SelectedSection != sectionKey) continue;

                foreach (var ms in value.Values)
                {
                    IControl editor = ms.OptionValueType switch
                    {
                        OptionValueType.Text => new TextOptionEditor
                        {
                            Meta = ms, 
                            [!TextOptionEditor.ValueProperty] = new Binding(ms.Key),
                        },
                        OptionValueType.Integer => new TextOptionEditor
                        {
                            Meta = ms, 
                            [!TextOptionEditor.ValueProperty] = new Binding(ms.Key),
                        },
                        OptionValueType.Decimal => new DecimalOptionEditor
                        {
                            Meta = ms, 
                            [!DecimalOptionEditor.ValueProperty] = new Binding(ms.Key),
                        },
                        OptionValueType.Point => new PointOptionEditor
                        {
                            Meta = ms, 
                            [!PointOptionEditor.ValueProperty] = new Binding(ms.Key),
                        },
                        OptionValueType.Toggle => new ToggleOptionEditor
                        {
                            Meta = ms, 
                            [!ToggleOptionEditor.ValueProperty] = new Binding(ms.Key),
                        },
                        OptionValueType.Option => new EnumOptionEditor
                        {
                            Meta = ms, 
                            [!EnumOptionEditor.ValueProperty] = new Binding(ms.Key),
                        },
                        OptionValueType.Path => new PathOptionEditor
                        {
                            Meta = ms, 
                            [!PathOptionEditor.ValueProperty] = new Binding(ms.Key),
                        },
                        OptionValueType.Color => new TextOptionEditor
                        {
                            Meta = ms, 
                            [!TextOptionEditor.ValueProperty] = new Binding(ms.Key),
                        },
                        _ => throw new ArgumentOutOfRangeException(),
                    };

                    options.Children.Add(editor);
                }
                

//                    .Select(editor => editor.Bind(DataContextProperty, OptionsManager.GetOptions().ToObservable()))    

                // lvOptions.ItemsSource = section.Value.Values;
            }
        
            //UpdateSections();
        
            //UpdateVisible();
            // SettingsManagerChanged?.Invoke(this, EventArgs.Empty);
        }
        //
        public SettingsEditor()
        {
            this.InitializeComponent();
            
            options = this.FindControl<StackPanel>("Options");
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
