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

namespace CorePOC.DataLayer.Repositories
{
    public class Repository : IRepository
    {
         IConnectionFactory _connectionFactory;
         IAuthFactory _authFactory;
        public Repository(IConnectionFactory connectionFactory,IAuthFactory authFactory)
        {
            _connectionFactory = connectionFactory;
            _authFactory=authFactory;
        }
        public string AddCardDetails(Card card)
        {
            if(!string.IsNullOrEmpty(card.cardnumber))
            {    
                card.cardnumber = Helpers.encodeString(card.cardnumber,12);            
                using (IDbConnection dbConnection = _connectionFactory.GetConnection)
                {
                    try
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
                        param.Add("isactive",card.isactive);
                        return SqlMapper.ExecuteScalar<string>(dbConnection, query, param, commandType: CommandType.StoredProcedure);                    
                    }
                    catch (Exception ex)
                    {
                        return $"Error in AddCardDetails Reposirory, Message is {ex.Message}";                    
                    }
                }                
            }
            else
            {
                return "Please enter card details";
            }
        }

        public string AddConsumer(Consumer consumer)
        {
            if(!string.IsNullOrEmpty(consumer.emailid))
            {
                consumer.pass = Helpers.encodeString(consumer.pass,consumer.pass.Length);
                using (IDbConnection dbConnection = _connectionFactory.GetConnection)
                {
                    try
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
                    catch (Exception ex)
                    {
                        return $"Error in AddConsumer Reposirory, Message is {ex.Message}";                    
                    }
                } 
            }
            else
            {
                return "Please pass the consumer details";                    
            }
           
        }


        public string GetConsumerDetails(Consumer consumer)
        {
            // ConsumerDetails consumerDetails=null;
            using (IDbConnection dbConnection = _connectionFactory.GetConnection)
            {
                try
                {
                    dbConnection.Open();
                    var query = "getconsumerdetails";
                    var param = new DynamicParameters();
                    param.Add("@emailid", consumer.emailid);
                    param.Add("@pass", consumer.pass);
                    var consumers =  SqlMapper.Query<string>(dbConnection, query, param, commandType: CommandType.StoredProcedure); 
                    return consumers.FirstOrDefault();
                }
                catch (Exception ex)
                {
                    return $"Error in GetConsumerDetails Reposirory, Message is {ex.Message}";                    
                }
            }
        }    

        public string GetCardDetails(Card card)
        {
            using (IDbConnection dbConnection = _connectionFactory.GetConnection)
            {
                try
                {
                    dbConnection.Open();
                    var query = "getcarddetails";
                    var param = new DynamicParameters();
                    param.Add("@emailid", card.userid);
                    var consumers =  SqlMapper.Query<string>(dbConnection, query, param, commandType: CommandType.StoredProcedure); 
                    return consumers.FirstOrDefault();
                }
                catch (Exception ex)
                {
                    return $"Error in GetCardDetails Reposirory, Message is {ex.Message}";                    
                }
            }
        }

        public string UpdateCardDetails(Card card)
        {
            if(! string.IsNullOrEmpty(card.cardnumber))
            {
                card.cardnumber = Helpers.encodeString(card.cardnumber,12);
                using (IDbConnection dbConnection = _connectionFactory.GetConnection)
                {
                    try
                    {
                        dbConnection.Open();
                        var query = "updateCardDetails";
                        var param = new DynamicParameters();
                        param.Add("@userid", card.userid);
                        param.Add("@cardnumber", card.cardnumber);
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

        public bool IsAuthorised(Auth auth)
        {
            Auth _auth = _authFactory.GetAuthDetails();
            if(auth.Username == _auth.Username && auth.Passowrd == _auth.Passowrd)
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