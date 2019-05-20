using System.Collections.Generic;
using System;
using MySql.Data.MySqlClient;

namespace UnSugarCoded.Models
{
  public class Log
  {
      private int _id;
      private DateTime _stampTime;
      private string _sugar;

      public Log(string sugar, DateTime stampTime, int id = 0)
      {
        _id = id;
        _stampTime = stampTime;
        _sugar = sugar;

      }

      public int GetId()
     {
       return _id;
     }

     public void SetId(int newId)
     {
       _id = newId;
     }

     public DateTime GetStampTime()
     {
       return _stampTime;
     }

     public void SetStampTime(Date stampTime)
     {
       _stampTime = stampTime;
     }

     public string GetSugar()
     {
       return _sugar;
     }

     public void SetSugar(string Sugar)
     {
       _sugar = sugar;
     }



     public void Save()
     {
       MySqlConnection conn = DB.Connection();
       conn.Open();
       var cmd = conn.CreateCommand() as MySqlCommand;
       cmd.CommandText = @"INSERT INTO log (sugar, profile_id) VALUES (@sugar, @profileId);";
       MySqlParameter sugarParam = new MySqlParameter();
       sugarParam.ParameterName = "@sugar";
       sugarParam.Value = this._sugar;
       cmd.Parameters.Add(sugarParam);
       MySqlParameter profileIdParam = new MySqlParameter();
       profileIdParam.ParameterName = "@profileId";
       profileIdParam.Value = this._profileId;
       cmd.Parameters.Add(profileIdParam);

       cmd.ExecuteNonQuery();
       _id = (int) cmd.LastInsertedId;
        conn.Close();
        if (conn != null)
        {
          conn.Dispose();
        }
      }
      public void Delete()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM logs WHERE id=@id;";
      MySqlParameter log_id= new MySqlParameter();
      log_id.ParameterName = "@id";
      log_id.Value = this._id;
      cmd.Parameters.Add(log_id);
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
    
        public void AddCategory(Category newCategory)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO categories_items (category_id, item_id) VALUES (@CategoryId, @ItemId);";
      MySqlParameter category_id = new MySqlParameter();
      category_id.ParameterName = "@CategoryId";
      category_id.Value = newCategory.GetId();
      cmd.Parameters.Add(category_id);
      MySqlParameter item_id = new MySqlParameter();
      item_id.ParameterName = "@ItemId";
      item_id.Value = _id;
      cmd.Parameters.Add(item_id);
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
  }
}
