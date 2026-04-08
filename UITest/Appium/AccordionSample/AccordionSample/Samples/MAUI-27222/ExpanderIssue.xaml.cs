using AccordionSample;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AccordionSample.Samples.MAUI_27222;

public partial class ExpanderIssue : ContentPage
{
    public ObservableCollection<Test>? ocTest { get; set; }

    public ExpanderIssue()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        Test t1 = new Test();
        t1.IsNotesEnabled = true;
        t1.sub = new Sub();
        t1.cb1Enabled = true;
        t1.cb2Enabled = true;
        t1.cb1 = true;
        t1.cb2 = true;
        t1.sub.wdesc = "Desc1";
        t1.sub.desc = "Sed ut perspiciatis, unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam eaque ipsa, quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt, explicabo.Nemo enim ipsam voluptatem, quia voluptas sit, aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos, qui ratione voluptatem sequi nesciunt, neque porro quisquam est, qui dolorem ipsum, quia dolor sit amet consectetur adipisci[ng] velit, sed quia non - numquam[do] eius modi tempora inci[di]dunt, ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim ad minima veniam, quis nostrum[d] exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem vel eum iure reprehenderit, qui in ea voluptate velit esse, quam nihil molestiae consequatur, vel illum, qui dolorem eum fugiat, quo voluptas nulla pariatur[33] At vero eos et accusamus et iusto odio dignissimos ducimus, qui blanditiis praesentium voluptatum deleniti atque corrupti, quos dolores et quas molestias excepturi sint, obcaecati cupiditate non-provident, similique sunt in culpa, qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio.Nam libero tempore, cum soluta nobis est eligendi optio, cumque nihil impedit, quo minus id, quod maxime placeat, facere possimus, omnis voluptas assumenda est, omnis dolor repellendus. Temporibus autem quibusdam et aut officiis debitis aut rerum necessitatibus saepe eveniet, ut et voluptates repudiandae sint et molestiae non - recusandae.Itaque earum rerum hic tenetur a sapiente delectus, ut aut reiciendis voluptatibus maiores alias consequatur aut perferendis doloribus asperiores repellat";

        t1.closeAllIsToggled = true;
        t1.accordionText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. ";
        Attachment a1 = new Attachment();
        a1.file_name = "ThisIsAFile.txt";
        Attachment a2 = new Attachment();
        a2.file_name = "ThisIsAnotherFile.txt";
        t1.ocAtt.Add(a1);
        t1.ocAtt.Add(a2);
        t1.AttachmentHeight = 50;
        t1.IsCompleteButtonVisible = true;

        Test t2 = new Test();
        t1.IsNotesEnabled = true;
        t2.sub = new Sub();
        t2.sub.wdesc = "Desc1";
        t2.sub.desc = "Desc2";
        t2.accordionText = "Duis aute irure dolor in reprehenderit";
        t2.IsCompleteButtonVisible = true;
        t2.AttachmentHeight = 10;

        Test t3 = new Test();
        t1.IsNotesEnabled = true;
        t3.sub = new Sub();
        t3.sub.wdesc = "Desc1";
        t3.sub.desc = "Sed ut perspiciatis, unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam eaque ipsa, quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt, explicabo.Nemo enim ipsam voluptatem, quia voluptas sit, aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos, qui ratione voluptatem sequi nesciunt, neque porro quisquam est, qui dolorem ipsum, quia dolor sit amet consectetur adipisci[ng] velit, sed quia non - numquam[do] eius modi tempora inci[di]dunt, ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim ad minima veniam, quis nostrum[d] exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem vel eum iure reprehenderit, qui in ea voluptate velit esse, quam nihil molestiae consequatur, vel illum, qui dolorem eum fugiat, quo voluptas nulla pariatur[33] At vero eos et accusamus et iusto odio dignissimos ducimus, qui blanditiis praesentium voluptatum deleniti atque corrupti, quos dolores et quas molestias excepturi sint, obcaecati cupiditate non-provident, similique sunt in culpa, qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio.Nam libero tempore, cum soluta nobis est eligendi optio, cumque nihil impedit, quo minus id, quod maxime placeat, facere possimus, omnis voluptas assumenda est, omnis dolor repellendus. Temporibus autem quibusdam et aut officiis debitis aut rerum necessitatibus saepe eveniet, ut et voluptates repudiandae sint et molestiae non - recusandae.Itaque earum rerum hic tenetur a sapiente delectus, ut aut reiciendis voluptatibus maiores alias consequatur aut perferendis doloribus asperiores repellat";
        t3.accordionText = "in voluptate velit esse cillum dolore eu fugiat ";
        t3.IsCompleteButtonVisible = false;
        t3.AttachmentHeight = 10;

        Test t4 = new Test();
        t1.IsNotesEnabled = true;
        t4.sub = new Sub();
        t4.sub.wdesc = "Desc1";
        t4.sub.desc = "Desc2";
        t4.accordionText = "nulla pariatur. Excepteur sint";
        t4.IsCompleteButtonVisible = true;
        t4.AttachmentHeight = 10;

        ocTest = new ObservableCollection<Test>();
        ocTest.Add(t1);
        ocTest.Add(t2);
        ocTest.Add(t3);
        ocTest.Add(t4);

        SubLV.ItemsSource = ocTest;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        SubLV.ItemsLayout!.ScrollToRowIndex(SubLV.DataSource!.DisplayItems.Count - 1, ScrollToPosition.End, true);
    }
}
