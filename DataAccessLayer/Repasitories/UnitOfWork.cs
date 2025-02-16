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
        private readonly IMapper _mapper;

        public UnitOfWork(AppDbContext appDbContext,
                        IMapper mapper,
                        ICategoryInterface categoryInterface,
                        IBookInterface bookInterface)
                        
        {
            _dbContext = appDbContext;
            _mapper = mapper;
            this.categoryInterface = categoryInterface;
            this.bookInterface = bookInterface;
        }

        public ICategoryInterface categoryInterface { get; }

        public IBookInterface bookInterface { get; }

        public void Dispose()
        =>  GC.SuppressFinalize(this);

        public async Task SaveChangesAsync()
        => await _dbContext.SaveChangesAsync();
    }
}
