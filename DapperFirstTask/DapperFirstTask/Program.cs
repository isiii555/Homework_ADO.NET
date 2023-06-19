using Dapper;
using DapperFirstTask.Models;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using System.Threading.Channels;

using SqlConnection connection = new(System.Configuration.ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

connection.Open();

#region WithoutJoin

//var sql = "SELECT * FROM Cars";

//var cars = connection.Query<Car>(sql).ToList();

//var sql2 = "SELECT * FROM Bicycles";

//var bicycles = connection.Query<Bicycle>(sql2).ToList();

//cars.ForEach(car => Console.WriteLine(car));

//bicycles.ForEach(bicycle => Console.WriteLine(bicycle));

#endregion

#region WithJoin

//var sql = "SELECT * FROM Cars INNER JOIN Transports ON Cars.VehicleID = Transports.Id";

//var cars = connection.Query<Car, Transport, Car>(sql, (car, transport) =>
//{
//    car.TransportId = transport.Id;
//    car.Transport = transport;
//    return car;
//}).ToList();

//var sql2 = "SELECT * FROM Bicycles INNER JOIN Transports ON Bicycles.VehicleID = Transports.Id";

//var bicycles = connection.Query<Bicycle, Transport, Bicycle>(sql2, (bicycle, transport) =>
//{
//    bicycle.TransportId = transport.Id;
//    bicycle.Transport = transport;
//    return bicycle;
//}).ToList();

//cars.ForEach(car => Console.WriteLine(car));

//bicycles.ForEach(bicycle => Console.WriteLine(bicycle));

#endregion

#region Insert

//string name1 = "Mercedes w210";

//var command = "INSERT INTO Transports(TransportName) VALUES(@name)";

//int affectedRows = connection.Execute(command, new {name = name1});

//Console.WriteLine($"Affected rows : {affectedRows}" );

#endregion

#region Delete

//var sql = "DELETE FROM Transports WHERE ID = 1";

//var affectedRows = connection.Execute(sql);

//Console.WriteLine($"Affected rows : {affectedRows}");

#endregion

#region Update

var transportName = "Rambo1";

var sql = "UPDATE Transports SET TransportName = @transportName WHERE Id = 2";

var affectedRows = connection.Execute(sql,new {transportName = transportName});

Console.WriteLine($"Affected rows : {affectedRows}");

#endregion
