using BrasilCashTest.Context;
using BrasilCashTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BrasilCashTest.Repositories
{
    public class CustomerRepository { 

    private readonly DataContext _context;

    public CustomerRepository (DataContext context)
    {
        _context = context;
    }

    public IEnumerable<Customer> GetAll(string name, string taxId, DateTime? createdAt)
    {
        var query = _context
            .Customer
            .Include(x => x.Address)
            .AsQueryable();

        if (!string.IsNullOrEmpty(name))
            query = query.Where(x => x.Name == name);

        if (!string.IsNullOrEmpty(taxId))
            query = query.Where(x => x.TaxId == taxId);

        if (createdAt != null)
            query = query.Where(x => x.CreatedAt.Date == createdAt.Value.Date);

        var customers = query.ToList();

        return customers;
    }

    public Customer Save(Customer customer)
    {
        _context.Customer.Add(customer);
        _context.SaveChanges();
        return customer;
    }
}
}
