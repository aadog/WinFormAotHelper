using System.ComponentModel;
using System.Windows.Forms;


namespace WinFormAotHelper
{
    public static class AotBindingHelper
    {
        extension(ProgressBar progressBar)
        {

            public void AddValueBinding(INotifyPropertyChanged observableObject, string propertyName,
                Func<int> getViewModelProperty,
                Action<int> setViewModelProperty)
            {
                progressBar.Value = getViewModelProperty();
                observableObject.PropertyChanged += (sender, e) =>
                {
                    if (e.PropertyName == propertyName)
                    {
                        progressBar.Value = getViewModelProperty();
                    }
                };
            }
        }
        extension(Button button)
        {

            public void AddEnabledBinding(INotifyPropertyChanged observableObject, string propertyName,
                Func<bool> getViewModelProperty,
                Action<bool> setViewModelProperty)
            {
                button.Enabled = getViewModelProperty();
                observableObject.PropertyChanged += (sender, e) =>
                {
                    if (e.PropertyName == propertyName)
                    {
                        button.Enabled = getViewModelProperty();
                    }
                };
                button.EnabledChanged += (sender, e) =>
                {
                    var result = button.Enabled;
                    setViewModelProperty(result);
                };
            }
        }

        extension(CheckBox checkBox)
        {
            public void AddCheckedBinding(INotifyPropertyChanged observableObject, string propertyName,
                Func<bool> getViewModelProperty,
                Action<bool> setViewModelProperty)
            {
                checkBox.Checked = getViewModelProperty();
                observableObject.PropertyChanged += (sender, e) =>
                {
                    if (e.PropertyName == propertyName)
                    {
                        checkBox.Checked = getViewModelProperty();
                    }
                };
                checkBox.CheckedChanged += (sender, e) =>
                {
                    var result = checkBox.Checked;
                    setViewModelProperty(result);
                };
            }
        }

        extension(Label label)
        {
            public void AddTextBinding<TProperty>(
                INotifyPropertyChanged observableObject,
                string propertyName,
                Func<TProperty> getViewModelProperty)
            {
                label.Text = getViewModelProperty()?.ToString();
                observableObject.PropertyChanged += (sender, e) =>
                {
                    if (e.PropertyName == propertyName)
                    {
                        label.Text = getViewModelProperty()?.ToString();
                    }
                };
            }
        }

        extension(RichTextBox richTextBox)
        {
            public void AddTextBinding<TProperty>(
                INotifyPropertyChanged observableObject,
                string propertyName,
                Func<TProperty> getViewModelProperty,
                Action<TProperty> setViewModelProperty
            )
            {
                richTextBox.Text = getViewModelProperty()?.ToString();
                observableObject.PropertyChanged += (sender, e) =>
                {
                    if (e.PropertyName == propertyName)
                    {
                        richTextBox.Text = getViewModelProperty()?.ToString();
                    }
                };
                richTextBox.TextChanged += (sender, e) =>
                {
                    var result = (TProperty)Convert.ChangeType(richTextBox.Text, typeof(TProperty));
                    setViewModelProperty(result);
                };
            }
        }

        extension(ComboBox comboBox)
        {
            public void AddTextBinding<TProperty>(
                INotifyPropertyChanged observableObject,
                string propertyName,
                Func<TProperty> getViewModelProperty,
                Action<TProperty> setViewModelProperty)
            {
                comboBox.Text = getViewModelProperty()?.ToString();
                observableObject.PropertyChanged += (sender, e) =>
                {
                    if (e.PropertyName == propertyName)
                    {
                        comboBox.Text = getViewModelProperty()?.ToString();
                    }
                };
                comboBox.SelectedValueChanged += (sender, e) =>
                {
                    var result = (TProperty)Convert.ChangeType(comboBox.Text, typeof(TProperty));
                    setViewModelProperty(result);
                };
            }
        }

        extension(TextBox textBox)
        {
            public void AddTextBinding<TProperty>(
                INotifyPropertyChanged observableObject,
                string propertyName,
                Func<TProperty> getViewModelProperty,
                Action<TProperty> setViewModelProperty)
            {
                textBox.Text = getViewModelProperty()?.ToString();
                observableObject.PropertyChanged += (sender, e) =>
                {
                    if (e.PropertyName == propertyName)
                    {
                        textBox.Text = getViewModelProperty()?.ToString();
                    }
                };
                textBox.TextChanged += (sender, e) =>
                {
                    var result = (TProperty)Convert.ChangeType(textBox.Text, typeof(TProperty));
                    setViewModelProperty(result);
                };
            }
        }
    }
}
