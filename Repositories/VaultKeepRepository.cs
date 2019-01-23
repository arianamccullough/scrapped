using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class VaultKeepRepository
  {
    private readonly IDbConnection _db;
    public VaultKeepRepository(IDbConnection db)
    {
      _db = db;

    }


    //GetKeepsbyVault
    public IEnumerable<Keep> GetKeepsByVaultId(int id, string userId)
    {
      return _db.Query<Keep>($@"
        SELECT * FROM vaultkeeps vk
        INNER JOIN keep k ON k.id = vk.keepId
        WHERE (vaultId = @id);
      ", new { id });
    }



    //AddVaultKeep
    public VaultKeep AddThing(VaultKeep vk)
    {
      int id = _db.ExecuteScalar<int>(@"
      INSERT INTO vaultkeeps(keepId, vaultId, userId)
      VALUES(@KeepId, @VaultId, @UserId);
      SELECT LAST_INSERT_ID();
      ", vk);
      vk.Id = id;
      return vk;
    }

    // update
    // public VaultKeep EditThing(VaultKeep vk)
    // {
    //   _db.Execute(@"
    //   UPDATE vaultkeeps SET (userId, vaultId, keepId")
    //   VALUES (@UserId, @GetKeepsByVaultId, @KeepId)
    //   WHERE id = @id", vk);
    //   return vk;
    // }

    //DeleteVaultKeep

    public bool DeleteThing(VaultKeep vk)
    {
      int success = _db.Execute(@"DELETE FROM vaultkeeps WHERE keepId = @KeepId AND vaultId = @VaultId", vk);
      return success != 0;

    }


  }
}