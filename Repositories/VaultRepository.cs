using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class VaultRepository
  {
    private readonly IDbConnection _db;

    public VaultRepository(IDbConnection db)
    {
      _db = db;
    }



    public IEnumerable<Vault> GetAll()
    {
      return _db.Query<Vault>("SELECT * FROM vaults;");
    }

    public Vault GetById(int id)
    {
      //super important to sanitize data
      return _db.QueryFirstOrDefault<Vault>($"SELECT * FROM vaults WHERE id= @id", new { id });
    }

    public Vault AddThing(Vault newthing)
    {
      int id = _db.ExecuteScalar<int>(@"INSERT INTO vaults
(name, description, location)
VALUES (@Name, @Description, @Location);
SELECT LAST_INSERT_ID();", newthing
      );
      if (id == 0)
      {
        return null;
      }
      newthing.Id = id;
      return newthing;
    }

    public Vault EditThing(int id, Vault newthing)
    {

      return _db.QueryFirstOrDefault<Vault>($@"UPDATE vaults SET
      Name = @Name,
      Description = @Description 
      Location = @Location,
      WHERE Id = @id;
      SELECT * FROM vaults WHERE id = @Id;", newthing);
    }


    public bool DeleteThing(int id)
    {

      int success = _db.Execute(@"DELETE FROM vaults WHERE id = @id", new { id });
      if (success == 0) return false;
      return true;
    }
  }
}