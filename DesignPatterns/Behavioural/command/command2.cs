using System;
using System.Text.RegularExpressions;

namespace DesignPatterns.Behavioural.command2
{

    public class Message
    {
        public string Text { get; set; }
        public Contact Sender { get; set; }
        public Contact Receiver { get; set; }
    }

    // Classe per rappresentare un contatto
    public class Contact
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }

    // Classe per rappresentare un gruppo
    public class Group
    {
        public string Name { get; set; }
        public List<Contact> Members { get; set; }
    }

    // Classe per gestire i messaggi
    public class MessageService
    {
        public void SendMessage(Message message)
        {
            // Logica per inviare il messaggio
            Console.WriteLine($"Messaggio inviato da {message.Sender.Name} a {message.Receiver.Name}: {message.Text}");
        }
    }

    // Classe per gestire i contatti
    public class ContactService
    {
        public void AddContact(Contact contact)
        {
            // Logica per aggiungere un contatto
            Console.WriteLine($"Contatto aggiunto: {contact.Name}, {contact.PhoneNumber}");
        }
    }

    // Classe per gestire i gruppi
    public class GroupService
    {
        public void CreateGroup(Group group)
        {
            // Logica per creare un gruppo
            Console.WriteLine($"Gruppo creato: {group.Name}");
            Console.WriteLine("Membri del gruppo:");
            foreach (var member in group.Members)
            {
                Console.WriteLine($"{member.Name}, {member.PhoneNumber}");
            }
        }
    }

    // Interfaccia ICommand che rappresenta un'operazione generica
    public interface ICommand
    {
        void Execute();
    }

    // Classe concreta per inviare messaggi
    public class SendMessageCommand : ICommand
    {
        private MessageService _messageService;
        private Message _message;

        public SendMessageCommand(MessageService messageService, Message message)
        {
            _messageService = messageService;
            _message = message;
        }

        public void Execute()
        {
            _messageService.SendMessage(_message);
        }
    }

    // Classe concreta per aggiungere contatti
    public class AddContactCommand : ICommand
    {
        private ContactService _contactService;
        private Contact _contact;

        public AddContactCommand(ContactService contactService, Contact contact)
        {
            _contactService = contactService;
            _contact = contact;
        }

        public void Execute()
        {
            _contactService.AddContact(_contact);
        }
    }

    // Classe concreta per creare gruppi
    public class CreateGroupCommand : ICommand
    {
        private GroupService _groupService;
        private Group _group;

        public CreateGroupCommand(GroupService groupService, Group group)
        {
            _groupService = groupService;
            _group = group;
        }

        public void Execute()
        {
            _groupService.CreateGroup(_group);
        }
    }

    // Classe che invoca i comandi
    public class MessagingApp
    {
        public void PerformOperation(ICommand command)
        {
            command.Execute();
        }
    }
}

