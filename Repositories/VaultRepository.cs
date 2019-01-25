using System;
using System.Collections.Generic;
using Dapper;
using Keepr.Models;
using System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Repositories
{

  public class VaultRepository
  {
    private readonly IDbConnection _db;

    public VaultRepository(IDbConnection db)
    {
      _db = db;
    }
    //GetVaultsByVaultId
    public Vault GetById(int id, string userId)
    {
      return _db.QueryFirstOrDefault<Vault>($@"SELECT * FROM vaults WHERE id = @id AND userId = @userId", new { id, userId });
    }

    //get user's vaults
    public IEnumerable<Vault> GetUserVaults(string userId)
    {
      return _db.Query<Vault>($@"SELECT * FROM vaults WHERE userId = @userId", new { userId });
    }

    //add a vault
    public VaultModel AddVault(VaultModel newVault)
    {
      int id = _db.ExecuteScalar<int>(@"INSERT INTO Vaults (userId, name, description, location)
      VALUES (@UserId, @Name, @Description, @Location);
      SELECT LAST_INSERT_ID();", newVault);
      if (id == 0)
      {
        return null;
      }
      newVault.Id = id;
      return newVault;
    }

    //delete a vault
    public bool DeleteVault(int vaultId, string userId)
    {
      int success = _db.Execute(@"DELETE FROM Vaults WHERE id = @vaultId AND userId = @userId", new { vaultId, userId });
      if (success == 0) return false;
      return true;
    }

  }
}