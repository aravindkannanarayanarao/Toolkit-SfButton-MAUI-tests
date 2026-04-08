using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccordionSample1
{
    public class ViewModel
    {
        public ObservableCollection<Model> Info { get; set; }

        public ViewModel()
        {
            Info = new ObservableCollection<Model>();
            Info.Add(new Model() { Name = "Item1", Description = "The Accordion is a vertically collapsible content panel that displays one or more panels at a time within the available space" });
            Info.Add(new Model()
            {
                Name = "Item2",
                Description = "Courses completed at other colleges may be considered for transfer credit at Rensselaer. Entering freshmen may transfer a maximum of 32 credit hours; this includes AP/IB credits or other equivalent credits." +
                "How the credits are applied to a student's degree program depends on the student's choice of major.Students may need to complete additional course work to fulfill the specific program requirements.The student should consult with their adviser for additional details."
            });
            Info.Add(new Model() { Name = "Item3", Description = "The Accordion is a vertically collapsible content panel that displays one or more panels at a time within the available space" });
            Info.Add(new Model()
            {
                Name = "Item4",
                Description = "Courses completed at other colleges may be considered for transfer credit at Rensselaer. Entering freshmen may transfer a maximum of 32 credit hours; this includes AP/IB credits or other equivalent credits." +
                "How the credits are applied to a student's degree program depends on the student's choice of major.Students may need to complete additional course work to fulfill the specific program requirements.The student should consult with their adviser for additional details."
            });
            Info.Add(new Model() { Name = "Item5", Description = "The Accordion is a vertically collapsible content panel that displays one or more panels at a time within the available space" });
            Info.Add(new Model()
            {
                Name = "Item6",
                Description = "Courses completed at other colleges may be considered for transfer credit at Rensselaer. Entering freshmen may transfer a maximum of 32 credit hours; this includes AP/IB credits or other equivalent credits." +
                "How the credits are applied to a student's degree program depends on the student's choice of major.Students may need to complete additional course work to fulfill the specific program requirements.The student should consult with their adviser for additional details."
            });
            Info.Add(new Model() { Name = "Item7", Description = "The Accordion is a vertically collapsible content panel that displays one or more panels at a time within the available space" });
            Info.Add(new Model()
            {
                Name = "Item8",
                Description = "Courses completed at other colleges may be considered for transfer credit at Rensselaer. Entering freshmen may transfer a maximum of 32 credit hours; this includes AP/IB credits or other equivalent credits." +
                "How the credits are applied to a student's degree program depends on the student's choice of major.Students may need to complete additional course work to fulfill the specific program requirements.The student should consult with their adviser for additional details."
            });
            Info.Add(new Model() { Name = "Item9", Description = "The Accordion is a vertically collapsible content panel that displays one or more panels at a time within the available space" });
            Info.Add(new Model()
            {
                Name = "Item10",
                Description = "Courses completed at other colleges may be considered for transfer credit at Rensselaer. Entering freshmen may transfer a maximum of 32 credit hours; this includes AP/IB credits or other equivalent credits." +
                "How the credits are applied to a student's degree program depends on the student's choice of major.Students may need to complete additional course work to fulfill the specific program requirements.The student should consult with their adviser for additional details."
            });
            Info.Add(new Model() { Name = "Item11", Description = "The Accordion is a vertically collapsible content panel that displays one or more panels at a time within the available space" });
            Info.Add(new Model()
            {
                Name = "Item12",
                Description = "Courses completed at other colleges may be considered for transfer credit at Rensselaer. Entering freshmen may transfer a maximum of 32 credit hours; this includes AP/IB credits or other equivalent credits." +
                "How the credits are applied to a student's degree program depends on the student's choice of major.Students may need to complete additional course work to fulfill the specific program requirements.The student should consult with their adviser for additional details."
            });
            Info.Add(new Model() { Name = "Item13", Description = "The Accordion is a vertically collapsible content panel that displays one or more panels at a time within the available space" });
            Info.Add(new Model()
            {
                Name = "Item14",
                Description = "Courses completed at other colleges may be considered for transfer credit at Rensselaer. Entering freshmen may transfer a maximum of 32 credit hours; this includes AP/IB credits or other equivalent credits." +
                "How the credits are applied to a student's degree program depends on the student's choice of major.Students may need to complete additional course work to fulfill the specific program requirements.The student should consult with their adviser for additional details."
            });
            Info.Add(new Model() { Name = "Item15", Description = "The Accordion is a vertically collapsible content panel that displays one or more panels at a time within the available space" });
            Info.Add(new Model()
            {
                Name = "Item16",
                Description = "Courses completed at other colleges may be considered for transfer credit at Rensselaer. Entering freshmen may transfer a maximum of 32 credit hours; this includes AP/IB credits or other equivalent credits." +
           "How the credits are applied to a student's degree program depends on the student's choice of major.Students may need to complete additional course work to fulfill the specific program requirements.The student should consult with their adviser for additional details."
            });
            Info.Add(new Model() { Name = "Item17", Description = "The Accordion is a vertically collapsible content panel that displays one or more panels at a time within the available space" });
            Info.Add(new Model()
            {
                Name = "Item18",
                Description = "Courses completed at other colleges may be considered for transfer credit at Rensselaer. Entering freshmen may transfer a maximum of 32 credit hours; this includes AP/IB credits or other equivalent credits." +
                "How the credits are applied to a student's degree program depends on the student's choice of major.Students may need to complete additional course work to fulfill the specific program requirements.The student should consult with their adviser for additional details."
            });
            Info.Add(new Model() { Name = "Item19", Description = "The Accordion is a vertically collapsible content panel that displays one or more panels at a time within the available space" });
            Info.Add(new Model()
            {
                Name = "Item20",
                Description = "Courses completed at other colleges may be considered for transfer credit at Rensselaer. Entering freshmen may transfer a maximum of 32 credit hours; this includes AP/IB credits or other equivalent credits." +
                "How the credits are applied to a student's degree program depends on the student's choice of major.Students may need to complete additional course work to fulfill the specific program requirements.The student should consult with their adviser for additional details."
            });
        }
    }

    public class Model
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
