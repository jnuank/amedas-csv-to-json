#!/usr/bin/env dotnet 
#:package CsvHelper@33.1.0

using CsvHelper;
using System;
using System.Globalization;
using CsvHelper.Configuration.Attributes;

Console.WriteLine("Hello, World!");

using var reader = new StreamReader(args[0]);
using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

var amedas = csv.GetRecords<Amedas>().ToList();

foreach (var record in amedas)
{
    Console.WriteLine($"{record.都道府県} {record.地点} {(record.現在値 != "" ? record.現在値 : "0")}mm {record.現在値の品質情報}");
}

public record Amedas
{
	public required string 都道府県 {get; set;}
	public required string 地点 {get; set;}
	[Name("現在時刻(年)")]
	public required string 現在年 {get; set;}
	[Name("現在時刻(月)")]
	public required string 現在月 {get; set;}
	[Name("現在時刻(日)")]
	public required string 現在日 {get; set;}
	[Name("現在時刻(時)")]
	public required string 現在時 {get; set;}
	[Name("現在時刻(分)")]
	public required string 現在分 {get; set;}
	[Name("現在値(mm)")]
	public required string 現在値 {get; set;}
	public required string 現在値の品質情報 {get; set;}
};
