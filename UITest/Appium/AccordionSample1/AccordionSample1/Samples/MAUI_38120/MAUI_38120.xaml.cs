namespace AccordionSample1;

public partial class MAUI_38120 : ContentPage
{
	public MAUI_38120()
	{
		InitializeComponent();
        this.BindingContext = this;
	}

    protected override void OnAppearing()
    {
        var infoList = new List<ItemInfo>();
        infoList.Add(new ItemInfo() { Name = "Cheese burger", Description = "Hamburger accompanied with melted cheese. The term itself is a portmanteau of the words cheese and hamburger. The cheese is usually sliced, then added a short time before the hamburger finishes cooking to allow it to melt." });
        infoList.Add(new ItemInfo() { Name = "Veggie burger", Description = "Veggie burger, garden burger, or tofu burger uses a meat analogue, a meat substitute such as tofu, textured vegetable protein, seitan (wheat gluten), Quorn, beans, grains or an assortment of vegetables, which are ground up and formed into patties." });
        infoList.Add(new ItemInfo() { Name = "Barbecue burger", Description = "Prepared with ground beef, mixed with onions and barbecue sauce, and then grilled. Once the meat has been turned once, barbecue sauce is spread on top and grilled until the sauce caramelizes." });
        infoList.Add(new ItemInfo() { Name = "Chili burger", Description = "Consists of a hamburger, with the patty topped with chili con carne." });
        Info = infoList;
    }

    public class ItemInfo
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }

    private List<ItemInfo> _infoList;
    public List<ItemInfo> Info
    {
        get => _infoList;
        set
        {
            _infoList = value;
            OnPropertyChanged();
        }
    }
}