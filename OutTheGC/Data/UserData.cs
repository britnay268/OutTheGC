using System;
using System.Security.Cryptography;
using OutTheGC.Models;
namespace OutTheGC.Data;

public class UserData
{
	public static List<User> Users = new()
	{
        new(){
            Id = new Guid("0eaed767-eecd-4d19-a853-9da895e78057"),
            FullName = "Britnay Gore",
            Email = "britnaygore268@gmail.com",
            Bio = "a ut erat id mauris vulputate elementumam varius.",
            ImageUrl = "",
            DateJoined = new DateTime(2017, 8, 15),
            Uid = ""
        },
        new(){
            Id = new Guid("8e98b8c4-6cf7-4817-b106-ffc59cbe83cc"),
            FullName = "Liz Paquette",
            Email = "liz.paquette08@gmail.com",
            Bio = "In sagittis dui vel nisl. Duis ac nibh. Fusce lacus purus, aliquet at, feugiat non, pretium quis, lectus.\n\nSuspendisse potenti. In eleifend quam a odio. In hac habitasse platea dictumst.",
            ImageUrl = "",
            DateJoined = new DateTime(2009, 6, 23),
            Uid = ""
        },
        new(){
            Id = new Guid("67a99b92-3485-4d39-8bce-33fe4fccfc85"),
            FullName = "Nigel Henry",
            Email = "nigel.henry@gmail.com",
            Bio = "Aenean lectus. Pellentesque eget nunc. Donec quis orci eget orci vehicula condimentum.\n\nCurabitur in libero ut massa volutpat convallis. Morbi odio odio, elementum eu, interdum eu, tincidunt in, leo. Maecenas pulvinar lobortis est.",
            ImageUrl = "",
            DateJoined = new DateTime(2006, 3, 12),
            Uid = ""
        },
        new(){
            Id = new Guid("59c5b94d-8015-48cd-bd86-0dbe486c4719"),
            FullName = "Emma Broermann",
            Email = "emariebroermann@gmail.com",
            Bio = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Proin risus. Praesent lectus.\n\nVestibulum quam sapien, varius ut, blandit non, interdum in, ante. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Duis faucibus accumsan odio. Curabitur convallis.",
            ImageUrl = "",
            DateJoined = new DateTime(2008, 3, 21),
            Uid = ""
        },
        new(){
            Id = new Guid("24fda663-5bf9-4e0d-8efd-111ae512dff5"),
            FullName = "Araya West",
            Email = "araya.west@rfsmart.com",
            Bio = "Praesent id massa id nisl venenatis lacinia. Aenean sit amet justo. Morbi ut odio.",
            ImageUrl = "",
            DateJoined = new DateTime(2020, 3, 23),
            Uid = ""
        }
    };
}

