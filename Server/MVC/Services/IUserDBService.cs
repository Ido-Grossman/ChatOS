﻿using MVC.Models;

namespace MVC.Services;

public interface IUserDBService
{
    public Task<List<User>> GetAll();

    public Task<User?> Get(string name);

    public Task<ICollection<Contact>> GetContacts(string userName);
        
    public Task<Contact?> GetContact(string userName, string friendName);
        
    public void AddContact(string userName, Contact contact);

    public void RemoveContact(string userName, string friendName);

    public Task<List<Message>?> GetMessages(string userName, string friendName);
        
    public Task<Message?> GetMessage(string userName, string friendName, int messageId);

    public Task<Message?> AddMessage(string userName, string friendName, string message, bool sent);

    public void AddUser(User user);
}