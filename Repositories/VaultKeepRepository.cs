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


    //GetVaultsbyUser
    public IEnumerable<Vault> GetVaultsbyUser(int id)
    {
      return _db.Query<Vault>($@"
        SELECT * FROM vaultkeeps vk
        INNER JOIN keep k ON k.id = vk.keepId
        WHERE (vaultId = @id);
      ", new { id });
    }


    //AddVaultKeep
    public VaultKeep AddVaultKeep(VaultKeep vk)
    {
      int id = _db.ExecuteScalar<int>(@"
      INSERT INTO vaultkeeps(keepId, vaultId)
      VALUES(@KeepId, @VaultId);
      SELECT LAST_INSERT_ID();
      ", vk);
      vk.Id = id;
      return vk;
    }

    //DeleteVaultKeep

    public bool DeleteVaultKeep(VaultKeep vk)
    {
      int success = _db.Execute(@"DELETE FROM vaultkeeps WHERE keepId = @KeepId AND vaultId = @VaultId", vk);
      return success != 0;

    }


  }
}