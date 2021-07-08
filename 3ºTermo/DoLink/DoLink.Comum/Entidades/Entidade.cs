using Flunt.Notifications;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace DoLink.Comum.Entidades
{
    public abstract class Entidade : Notifiable
    {
        public Entidade()
        {}

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}
