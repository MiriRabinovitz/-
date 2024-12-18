
using Microsoft.AspNetCore.Http.HttpResults;
using WebApplicationHBH.Contracts;
using WebApplicationHBH.Models;

namespace WebApplicationHBH.Routes;

public static class ContactFormRoutes
{
    public static IEndpointRouteBuilder MapContactForm(this IEndpointRouteBuilder endpoints)
    {
        var contactFormGroup = endpoints.MapGroup("api/contact");
        contactFormGroup.MapGet("", GetAll);
        contactFormGroup.MapPost("", AddNewContactForm);
        contactFormGroup.MapDelete("{id}", Delete);
        contactFormGroup.MapPut("", Update);
        return endpoints;
    }
 
    static async Task<Ok<List<ContactForm>>> GetAll(IContractFormRepository rep)
    {
        var res = await rep.GetAllContactForms();
        return TypedResults.Ok(res);
    }
    static async Task<Ok<ContactForm>> Update(IContractFormRepository rep,ContactForm cf)
    {
        var res = await rep.UpdateContactForm(cf);
        if (res == null) return NotFound(); 
        else TypedResults.Ok(res);

    }
    static async Task<Ok<ContactForm>> Delete(IContractFormRepository rep, int id)
    {
        var res = await rep.DeleteContactForm(id);
        if (res ==null) return TypedResults.NotFound();
        else return TypedResults.NoContent();

    }

    static async Task<Created<ContactForm>> AddNewContactForm(IContractFormRepository rep, ContactForm cf)
    {
        var res = await rep.CreateNewContactForm(cf);
        return TypedResults.Created($"api/contact/{res.Id}", res);
    }
}
