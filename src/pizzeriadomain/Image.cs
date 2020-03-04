using System;
public class Image{
    public Guid Id{get;set;}
    public string Url {get;set;}
    public static Image Create(string url){
        return new Image(){
            Id=Guid.NewGuid(),
            Url = url
        };
    }
}