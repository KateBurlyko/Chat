using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Forms;

namespace Chat
{
    public class ActionsW
    {
        private void AddNewUserToList(string name, ObservableCollection<string> listOfUsers)
        {
            listOfUsers.Add(name);
        }

        private void DeleteUserFromList(string name, ObservableCollection<string> listOfUsers)
        {
            listOfUsers.Remove(name);
        }

        public void AddOrRemoveUserFromList(string message, ObservableCollection<string> listOfUsers)
        {
            string[] mess = message.Split(new char[] { ' ' });
            switch (mess[1])
            {
                case "intered":
                    AddNewUserToList(mess[0], listOfUsers);
                    break;
                case "leaved":
                    DeleteUserFromList(mess[0], listOfUsers);
                    break;
            }
        }
    }
}
