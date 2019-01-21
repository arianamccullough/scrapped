using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class KeepRepository
  {
    private readonly IDbConnection _db;

    public KeepRepository(IDbConnection db)
    {
      _db = db;
    }



    public IEnumerable<Keep> GetAll()
    {
      return _db.Query<Keep>("SELECT * FROM keeps;");
    }

    public Keep GetById(int id)
    {
      //super important to sanitize data
      return _db.QueryFirstOrDefault<Keep>($"SELECT * FROM keeps WHERE id= @id", new { id });
    }

    public Keep AddThing(Keep newthing)
    {
      int id = _db.ExecuteScalar<int>(@"INSERT INTO keeps
(name, description, img, views, saves, location, isprivate, userId)
VALUES (@Name, @Description, @Img, @Views, @Saves, @Location, @IsPrivate, @UserId);
SELECT LAST_INSERT_ID();", newthing
      );
      if (id == 0)
      {
        return null;
      }
      newthing.Id = id;
      return newthing;
    }

    public Keep EditThing(int id, Keep newthing)
    {

      return _db.QueryFirstOrDefault<Keep>($@"UPDATE keeps SET
      Name = @Name,
      Description = @Description,
      Img = @Img,
      View = @View,
      Save = @Save,
      WHERE Id = @id;
      SELECT * FROM keeps WHERE id = @Id;", newthing);
    }


    public bool DeleteThing(int id)
    {

      int success = _db.Execute(@"DELETE FROM keeps WHERE id = @id", new { id });
      if (success == 0) return false;
      return true;
    }
  }
}