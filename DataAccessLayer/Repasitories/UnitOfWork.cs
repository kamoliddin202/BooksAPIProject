using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataAccessLayer.Data;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccessLayer.Repasitories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper mapper;

        public UnitOfWork(AppDbContext appDbContext,
                        IMapper mapper)
        {
            _dbContext = appDbContext;
            this.mapper = mapper;
        }
        public IBookInterface Book { get; }

        public ICategoryInterface Category {  get; }

        public async void Dispose()
        => await _

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
