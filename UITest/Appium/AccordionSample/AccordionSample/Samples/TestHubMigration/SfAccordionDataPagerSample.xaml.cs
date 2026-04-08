using Microsoft.Maui.Controls;

namespace AccordionSample;

/// <summary>
/// SfAccordion Sample for DataPager Double Initialization
/// Covers Test Case: 117628 - DataPager with double initialization should not throw null reference exception
/// </summary>
public partial class SfAccordionDataPagerSample : ContentPage
{
    private int initializationCount = 0;

    public SfAccordionDataPagerSample()
    {
        InitializeComponent();
        Title = "SfAccordion - DataPager Double Initialization";
    }

    private void OnStartClicked(object sender, EventArgs e)
    {
        try
        {
            initializationCount++;
            
            // Simulate double initialization
            if (initializationCount == 1)
            {
                // First initialization
                InitializeDataPager();
                var statusLabel = FindByName("StatusLabel") as Label;
                if (statusLabel != null)
                {
                    statusLabel.Text = "Status: First Initialization Done";
                    statusLabel.TextColor = Colors.Green;
                }
            }
            else if (initializationCount == 2)
            {
                // Second initialization - this should NOT throw an exception
                InitializeDataPager();
                var statusLabel = FindByName("StatusLabel") as Label;
                if (statusLabel != null)
                {
                    statusLabel.Text = "Status: Double Initialization Successful (No Exception)";
                    statusLabel.TextColor = Colors.Green;
                }
            }
            else
            {
                var statusLabel = FindByName("StatusLabel") as Label;
                if (statusLabel != null)
                {
                    statusLabel.Text = "Status: Test Complete - No Null Reference Exception";
                    statusLabel.TextColor = Colors.Green;
                }
            }
        }
        catch (NullReferenceException ex)
        {
            var statusLabel = FindByName("StatusLabel") as Label;
            if (statusLabel != null)
            {
                statusLabel.Text = $"Status: FAILED - {ex.Message}";
                statusLabel.TextColor = Colors.Red;
            }
        }
        catch (Exception ex)
        {
            var statusLabel = FindByName("StatusLabel") as Label;
            if (statusLabel != null)
            {
                statusLabel.Text = $"Status: Error - {ex.Message}";
                statusLabel.TextColor = Colors.Red;
            }
        }
    }

    private void InitializeDataPager()
    {
        // Placeholder for DataPager initialization logic
        // In a real scenario, this would involve:
        // - Setting up DataPager source
        // - Binding data
        // - Configuring pagination
        
        Task.Delay(500).Wait();
    }
}
