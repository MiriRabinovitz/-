using WebApplicationHBH.Contracts;
using WebApplicationHBH.DataContext;
using WebApplicationHBH.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationHBH.Services;

public class ContactFormRepository (ContacFormDbContext dbContext): IContractFormRepository
{
    public async Task<ContactForm> CreateNewContactForm(ContactForm form)
    {
        await dbContext.ContactForm.AddAsync(form);
        await dbContext.SaveChangesAsync();
        return form;
    }

    public Task<ContactForm> DeleteContactForm(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<ContactForm>> GetAllContactForms()
    {
        throw new NotImplementedException();
    }

    public Task<ContactForm> UpdateContactForm(ContactForm form)
    {
        throw new NotImplementedException();
    }
}
