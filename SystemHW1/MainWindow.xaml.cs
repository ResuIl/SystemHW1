using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;

namespace SystemHW1;

public partial class MainWindow : Window
{
    public ObservableCollection<Process> Processes { get; set; }

    public MainWindow()
    {
        InitializeComponent();
        DataContext = this;
        Processes = new(Process.GetProcesses());
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if (lv_Processes.SelectedItem is null)
            return;

        if (lv_Processes.SelectedItem is Process process)
        {
            try
            {
                process.Kill();
                Processes.Remove(process);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        
        if (!string.IsNullOrWhiteSpace(tBox_ProcessName.Text))
            Process.Start(tBox_ProcessName.Text);
    }
}
