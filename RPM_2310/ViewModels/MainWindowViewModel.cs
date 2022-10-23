using RPM_2310.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RPM_2310.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        // listbox с телефонами
        // listbox c radioButtons
        private List<Phone> _phones= new List<Phone>(); 
        private List<RadioButton> _radioButtons= new List<RadioButton>();
        private TextBlock _textBlock;

        public IReadOnlyCollection<Phone> Phones 
        {
            get => _phones.AsReadOnly();
            set 
            {
                _phones = value.ToList();
                NotifyPropertyChanged();
            }
           
        
        }
        public IReadOnlyCollection<RadioButton> Buttons {

            get => _radioButtons.AsReadOnly();
            set
            {
                _radioButtons = value.ToList();
                NotifyPropertyChanged();
            }
            
        }

        public TextBlock TextColunm
        {
            get => _textBlock;
            set => _textBlock = value;
        }


        public MainWindowViewModel()
        {
            Phones = Enumerable.Range(0, 15).Select(x => new Phone(StringGenerator.Generate(10), StringGenerator.Generate(15))).ToList().AsReadOnly();
            var temp = Enumerable.Range(0, 20).Select(x => new RadioButton()).ToList();
            temp.ForEach(x =>
            {
                x.Content = StringGenerator.Generate(17);
                x.GroupName = "group";
            });
            Buttons = temp.AsReadOnly();

            _textBlock = new TextBlock();
            Enumerable.Range(0, new Random().Next(15, 60)).ToList().ForEach(x =>
            _textBlock.Inlines.Add(StringGenerator.GenerateTextLine()));
            NotifyPropertyChanged(nameof(TextColunm));
            

        }


        public event PropertyChangedEventHandler? PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
    
}
