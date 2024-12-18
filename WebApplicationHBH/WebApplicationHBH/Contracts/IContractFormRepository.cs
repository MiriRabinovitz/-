using WebApplicationHBH.Models;

namespace WebApplicationHBH.Contracts;

public interface IContractFormRepository
{

    Task<ContactForm> CreateNewContactForm(ContactForm form);
    Task<ContactForm> DeleteContactForm(int id);
    Task<List<ContactForm>> GetAllContactForms();
    Task<ContactForm> UpdateContactForm(ContactForm form);
}
