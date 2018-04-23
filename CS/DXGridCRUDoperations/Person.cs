// Developer Express Code Central Example:
// How to implement simple copy/paste operations in the GridView from a toolbar menu
// 
// This example illustrates how to implement simple copy/paste/delete operations in
// the GridView.
// You can find more in the article
// http://www.devexpress.com/scid=A1266
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E4528

using System;

namespace DXGridCRUDoperations {
    public class Person {
        string firstName;
        string secondName;
        string comments;
        public Person(string firstName, string secondName) {
            this.firstName = firstName;
            this.secondName = secondName;
            comments = String.Empty;
        }
        public Person(string firstName, string secondName, string comments)
            : this(firstName, secondName) {
            this.comments = comments;
        }
        public Person()
        {

        }
        public string FirstName {
            get { return firstName; }
            set { firstName = value; }
        }
        public string SecondName {
            get { return secondName; }
            set { secondName = value; }
        }
        public string Info {
            get { return comments; }
            set { comments = value; }
        }
    }
}