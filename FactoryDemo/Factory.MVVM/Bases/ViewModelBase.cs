using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.MVVM.Bases
{
    public abstract class ViewModelBase<TModel> : BindableBaseEx where TModel : INotifyPropertyChanged
    {

    }
}
