using System;
using System.Collections.Generic;
using Dapper;
using Keepr.Models;
using System.Data;
using Microsoft.AspNetCore.Http;

namespace Keepr.Repositories
{

  public class KeepRepository
  {
    private readonly IDbConnection _db;

    public KeepRepository(IDbConnection db)
    {
      _db = db;
    }
    //get everyone's keeps
    public IEnumerable<Keep> GetHomeKeeps()
    {
      return _db.Query<Keep>("SELECT * FROM keeps WHERE isPrivate = 0");
    }

    //get my keeps
    public IEnumerable<Keep> GetMyKeeps(string userId)
    {
      return _db.Query<Keep>("SELECT * FROM keeps WHERE userId = @userId", new { userId });
    }

    //get a single keep
    public Keep GetAKeep(int keepId)
    {
      return _db.QueryFirstOrDefault<Keep>("SELECT * FROM keeps WHERE id = @keepId", new { keepId });
    }

    //add a keep
    public KeepModel AddKeep(KeepModel setKeep)
    {
      int id = _db.ExecuteScalar<int>($@"INSERT INTO Keeps (name, description, userId, isPrivate, img, views, saves)
      VALUES (@Name, @Description, @UserId, @IsPrivate, @Img, @Views, @Saves);
      SELECT LAST_INSERT_ID();", setKeep);
      if (id == 0)
      {
        return null;
      }
      setKeep.Id = id;
      return setKeep;
    }

    public bool DeleteKeep(int keepId, string userId)
    {
      int success = _db.Execute(@"DELETE FROM Keeps WHERE id = @keepId AND userId = @userId", new { keepId, userId });
      return success != 0;
    }

    public Keep UpdateKeep(int id, Keep updatedKeep)
    {
      try
      {
        return _db.QueryFirstOrDefault<Keep>($@" UPDATE keeps SET
        Id = @Id,
        UserId = @UserId,
        Name = @Name,
        Description = @Description,
        Img = @Img,
        IsPrivate = @IsPrivate,
        Views = @Views,
        Saves = @Saves
        WHERE id = @Id;

        SELECT * FROM keeps WHERE id = @Id;
        ", updatedKeep);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return null;
      }
    }

  }
}

