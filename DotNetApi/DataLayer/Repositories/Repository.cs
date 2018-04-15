using CorePOC.Model;
using Dapper;
using CorePOC.DataLayer.InfraStructure;
using System.Data;
using Newtonsoft;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using CorePOC.Helper;
using System.Data.SqlClient;

namespace CorePOC.DataLayer.Repositories
{
    public class Repository : IRepository
    {
        IConnectionFactory _connectionFactory;
        IAuthFactory _authFactory;
        public Repository(IConnectionFactory connectionFactory, IAuthFactory authFactory)
        {
            _connectionFactory = connectionFactory;
            _authFactory = authFactory;
        }
        public string AddCardDetails(Card card)
        {
            card.cardnumber = Helpers.encodeString(card.cardnumber, 12);
            using (IDbConnection dbConnection = _connectionFactory.GetConnection)
            {
                dbConnection.Open();
                /* Call via inline query: It is working*/
                //dbConnection.Execute($"INSERT INTO Consumer(email,first_name,last_name,password) VALUES('{consumer.Email}','{consumer.FirstName}','{consumer.LastName}','{consumer.Password}');");
                /* Calling via proc */
                var query = "addcard";
                var param = new DynamicParameters();
                param.Add("@userid", card.userid);
                param.Add("@cardnumber", card.cardnumber);
                param.Add("@cardtype", card.cardtype);
                param.Add("@expirydate", card.expirydate);
                param.Add("isactive", card.isactive);
                return SqlMapper.ExecuteScalar<string>(dbConnection, query, param, commandType: CommandType.StoredProcedure);                    
            }
            
        }

        public async Task<string> AddCardDetailsAsync(Card card)
        {
            card.cardnumber = Helpers.encodeString(card.cardnumber, 12);
                using (IDbConnection dbConnection = _connectionFactory.GetConnection)
                {
                    dbConnection.Open();
                    /* Call via inline query: It is working*/
                    //dbConnection.Execute($"INSERT INTO Consumer(email,first_name,last_name,password) VALUES('{consumer.Email}','{consumer.FirstName}','{consumer.LastName}','{consumer.Password}');");
                    /* Calling via proc */
                    var query = "addcard";
                    var param = new DynamicParameters();
                    param.Add("@userid", card.userid);
                    param.Add("@cardnumber", card.cardnumber);
                    param.Add("@cardtype", card.cardtype);
                    param.Add("@expirydate", card.expirydate);
                    param.Add("isactive", card.isactive);
                    return await SqlMapper.ExecuteScalarAsync<string>(dbConnection, query, param, commandType: CommandType.StoredProcedure);
                    
                }
            
        }
        public string AddConsumer(Consumer consumer)
        {
            consumer.pass = Helpers.encodeString(consumer.pass, consumer.pass.Length);
                using (IDbConnection dbConnection = _connectionFactory.GetConnection)
                {
                    
                        dbConnection.Open();
                        /* Call via inline query: It is working*/
                        //dbConnection.Execute($"INSERT INTO Consumer(email,first_name,last_name,password) VALUES('{consumer.Email}','{consumer.FirstName}','{consumer.LastName}','{consumer.Password}');");
                        /* Calling via proc */
                        var query = "addConsumer";
                        var param = new DynamicParameters();
                        param.Add("@emailid", consumer.emailid);
                        param.Add("@firstname", consumer.firstname);
                        param.Add("@lastname", consumer.lastname);
                        param.Add("@pass", consumer.pass);
                        return SqlMapper.ExecuteScalar<string>(dbConnection, query, param, commandType: CommandType.StoredProcedure);
                    
                }
            
        }

        public async Task<string> AddConsumerAsync(Consumer consumer)
        {
            consumer.pass = Helpers.encodeString(consumer.pass, consumer.pass.Length);
                using (IDbConnection dbConnection = _connectionFactory.GetConnection)
                {
                        dbConnection.Open();
                        /* Call via inline query: It is working*/
                        //dbConnection.Execute($"INSERT INTO Consumer(email,first_name,last_name,password) VALUES('{consumer.Email}','{consumer.FirstName}','{consumer.LastName}','{consumer.Password}');");
                        /* Calling via proc */
                        var query = "addConsumer";
                        var param = new DynamicParameters();
                        param.Add("@emailid", consumer.emailid);
                        param.Add("@firstname", consumer.firstname);
                        param.Add("@lastname", consumer.lastname);
                        param.Add("@pass", consumer.pass);
                        return await SqlMapper.ExecuteScalarAsync<string>(dbConnection, query, param, commandType: CommandType.StoredProcedure);
                    
                }
            
        }

        public string GetConsumerDetails(Consumer consumer)
        {

            consumer.pass = Helpers.encodeString(consumer.pass, consumer.pass.Length);
            using (IDbConnection dbConnection = _connectionFactory.GetConnection)
            {
                dbConnection.Open();
                    var query = "getconsumerdetails";
                    var param = new DynamicParameters();
                    param.Add("@emailid", consumer.emailid);
                    param.Add("@pass", consumer.pass);

                    var consumers = SqlMapper.Query<string>(dbConnection, query, param, commandType: CommandType.StoredProcedure);
                    if (consumers != null)
                    {
                        return consumers.FirstOrDefault();
                    }
                    else
                    {
                        return "Consumer details not available";
                    }


                
            }
        }

        public async Task<string> GetConsumerDetailsAsync(Consumer consumer)
        {
            consumer.pass = Helpers.encodeString(consumer.pass, consumer.pass.Length);
            using (IDbConnection dbConnection = _connectionFactory.GetConnection)
            {
                dbConnection.Open();
                    var query = "getconsumerdetails";
                    var param = new DynamicParameters();
                    param.Add("@emailid", consumer.emailid);
                    param.Add("@pass", consumer.pass);

                    var consumers = await SqlMapper.QueryAsync<string>(dbConnection, query, param, commandType: CommandType.StoredProcedure);
                    if (consumers != null)
                    {
                        return consumers.FirstOrDefault();
                    }
                    else
                    {
                        return "Consumer details not available";
                    }
               
            }
        }

        public string GetCardDetails(Card card)
        {
            using (IDbConnection dbConnection = _connectionFactory.GetConnection)
            {
                dbConnection.Open();
                    var query = "getcarddetails";
                    var param = new DynamicParameters();
                    param.Add("@userid", card.userid);
                    var consumers = SqlMapper.Query<string>(dbConnection, query, param, commandType: CommandType.StoredProcedure);
                    return consumers.FirstOrDefault();
                
            }
        }

        public async Task<string> GetCardDetailsAsync(Card card)
        {
            using (IDbConnection dbConnection = _connectionFactory.GetConnection)
            {
                dbConnection.Open();
                    var query = "getcarddetails";
                    var param = new DynamicParameters();
                    param.Add("@userid", card.userid);
                    var consumers = await SqlMapper.QueryAsync<string>(dbConnection, query, param, commandType: CommandType.StoredProcedure);
                    return consumers.FirstOrDefault();
                
            }
        }

        public string UpdateCardDetails(Card card)
        {
            if (!string.IsNullOrEmpty(card.cardnumber))
            {
                card.cardnumber = Helpers.encodeString(card.cardnumber, 12);
                using (IDbConnection dbConnection = _connectionFactory.GetConnection)
                {
                    try
                    {
                        dbConnection.Open();
                        var query = "updateCardDetails";
                        var param = new DynamicParameters();
                        param.Add("@userid", card.userid);
                        param.Add("@cardid", card.cardid);
                        param.Add("@cardtype", card.cardtype);
                        param.Add("@expirydate", card.expirydate);
                        param.Add("@isactive", card.isactive);
                        return SqlMapper.ExecuteScalar<string>(dbConnection, query, param, commandType: CommandType.StoredProcedure);
                    }
                    catch (Exception ex)
                    {
                        return $"Error in Update card details Reposirory, Message is {ex.Message}";
                    }
                }
            }
            else
            {
                return "Please provide the card details";
            }
        }

        public async Task<string> UpdateCardDetailsAsync(Card card)
        {
            if (!string.IsNullOrEmpty(card.cardnumber))
            {
                card.cardnumber = Helpers.encodeString(card.cardnumber, 12);
                using (IDbConnection dbConnection = _connectionFactory.GetConnection)
                {
                    dbConnection.Open();
                        var query = "updateCardDetails";
                        var param = new DynamicParameters();
                        param.Add("@userid", card.userid);
                        param.Add("@cardid", card.cardid);
                        param.Add("@cardtype", card.cardtype);
                        param.Add("@expirydate", card.expirydate);
                        param.Add("@isactive", card.isactive);
                        return await SqlMapper.ExecuteScalarAsync<string>(dbConnection, query, param, commandType: CommandType.StoredProcedure);
                    
                }
            }
            else
            {
                return "Please provide the card details";
            }
        }

        public newConsumer GetConsumerMap(Consumer consumer)
        {
            newConsumer consumerDetails = null;
            using (IDbConnection dbConnection = _connectionFactory.GetConnection)
            {
                try
                {
                    dbConnection.Open();
                    var query = "getconsumer";
                    var param = new DynamicParameters();
                    param.Add("@email_id", consumer.emailid);
                    param.Add("@pass", consumer.pass);

                    // For Single result set which needs to be mapped to muliple object
                    var consumers = SqlMapper.Query<newConsumer, NewCard, newConsumer>(dbConnection,
                    query, (a, b) => { a.card = b; return a; }, param, splitOn: "cardid", commandType: CommandType.StoredProcedure
                    );

                    // For Multiple result set from DB
                    // using(var consumers =  SqlMapper.QueryMultiple(dbConnection,query, param, null, null, CommandType.StoredProcedure ))
                    // {
                    //      newConsumer obj=   consumers.Read<newConsumer>().FirstOrDefault();
                    //      obj.cardDetails = consumers.Read<NewCard>().ToList();

                    // }
                    consumerDetails = consumers.FirstOrDefault();
                    return consumerDetails;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public bool IsAuthorised(Auth auth)
        {
            Auth _auth = _authFactory.GetAuthDetails();
            if (auth.Username == _auth.Username && auth.Passowrd == _auth.Passowrd)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}