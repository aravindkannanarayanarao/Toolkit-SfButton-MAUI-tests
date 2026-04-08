using System.Collections.ObjectModel;

namespace AccordionSample;

public partial class MAUI_30507 : ContentPage
{
    public MAUI_30507()
    {
        InitializeComponent();
        BindingContext = new Repository();
    }

    private void Button_OnClicked(object sender, EventArgs e)
    {
        var vm = ((Repository)BindingContext);

        vm.ChipsCount++;

        vm.SelectedItem.MoreItems.Add(new Item()
        {
            Name = $"Chip {vm.ChipsCount}"
        });
    }
}

public class Item
{
    public string? Name { get; set; }

    public ObservableCollection<Item> MoreItems { get; set; } = new ObservableCollection<Item>();
}

public class Repository
{
    public int ChipsCount = 6;
    public ObservableCollection<Item> Items { get; set; }

    public Item SelectedItem { get; set; }

    public Repository()
    {
        Items = new ObservableCollection<Item>()
        {
            new Item()
            {
                Name = "Item 1",
            },
            new Item()
            {
                Name = "Item 2",
                MoreItems = new ObservableCollection<Item>()
                {
                    new Item()
                    {
                        Name = "Chip 1",
                    },
                    new Item()
                    {
                        Name = "Chip 2"
                    },
                    new Item()
                    {
                        Name = "Chip 3",
                    },
                    new Item()
                    {
                        Name = "Chip 4"
                    }
                }
            },
            new Item()
            {
                Name = "Item 3",
                MoreItems = new ObservableCollection<Item>()
                {
                    new Item()
                    {
                        Name = "Chip 5",
                    },
                    new Item()
                    {
                        Name = "Chip 6"
                    }
                }
            },
            new Item()
            {
                Name = "Item 4",
            },
        };

        SelectedItem = Items[0];
    }
}

public class MyArray
{
    public string[] NameArray = new string[] { "Srini", "Vivek", "Rahul", "Ramu" };

    public MyArray()
    {
        Console.WriteLine("Item 1" + NameArray[0]);
        ReorderElement(0);
        Console.WriteLine("Item 2" + NameArray[1]);
        ReorderElement(1);
    }


    public void ReorderElement(int oldIndex)
    {
        int newIndex = (NameArray.Count() - 1);
        if (oldIndex == newIndex)
            return;

        var tmp = NameArray[oldIndex];
        if (newIndex < oldIndex)
        {
            Array.Copy(NameArray, newIndex, NameArray, newIndex + 1, oldIndex - newIndex);
        }
        else
        {
            Array.Copy(NameArray, oldIndex + 1, NameArray, oldIndex, newIndex - oldIndex);
        }
        NameArray[newIndex] = tmp;
    }
}