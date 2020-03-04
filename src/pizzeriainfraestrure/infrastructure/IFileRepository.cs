using System;
using pizzeria.Domain;
namespace pizzeria.infrastructure{
    public interface IFileRepository
    {
              void Add(File image);
              byte[] Get(Guid Id);
              void Delete(Guid Id);

    }

     
}