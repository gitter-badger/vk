﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using VkNet.Enums.SafetyEnums;

namespace VkNet.Model
{
	using System;

	using VkNet.Categories;
	using VkNet.Enums;
	using VkNet.Utils;

	/// <summary>
	/// Информация о сообществе (группе).
	/// См. описание <see href="http://vk.com/dev/fields_groups"/>.
	/// </summary>
	public class GroupInfo
	{
		#region Стандартные поля

		/// <summary>
		/// Название сообщества.
		/// </summary>
		public string Title { get; set; }
		/// <summary>
		/// Описание сообщества.
		/// </summary>
		public string Description
		{ get; set; }
		/// <summary>
		/// Gets or sets the address.
		/// </summary>
		public string Address
		{ get; set; }

		/// <summary>
		/// Место, указанное в информации о сообществе.
		/// </summary>
		public Place Place
		{ get; set; }
		/// <summary>
		/// Стена.
		/// </summary>
		public ContentAccess? Wall
		{ get; set; }
		/// <summary>
		/// Фотографии.
		/// </summary>
		public ContentAccess? Photos
		{ get; set; }
		/// <summary>
		/// Видеозаписи.
		/// </summary>
		public ContentAccess? Video
		{ get; set; }
		/// <summary>
		/// Аудиозаписи.
		/// </summary>
		public ContentAccess? Audio
		{ get; set; }
		/// <summary>
		/// Документы.
		/// </summary>
		public ContentAccess? Docs
		{ get; set; }
		/// <summary>
		/// Обсуждения.
		/// </summary>
		public ContentAccess? Topics
		{ get; set; }
		/// <summary>
		/// Материалы.
		/// </summary>
		public ContentAccess? Wiki
		{ get; set; }
		/// <summary>
		/// Тип группы.
		/// </summary>
		public GroupPublicity? Access
		{ get; set; }
		/// <summary>
		/// Тематика сообщества.
		/// </summary>
		public GroupSubjects? Subject
		{ get; set; }

		/// <summary>
		/// Адрес сайта, который будет указан в информации о группе 
		/// </summary>
		public string Website { get; set; }

		/// <summary>
		/// Контакты: (доступно только для публичных страниц).
		/// </summary>
		public bool? Contacts
		{ get; set; }

		/// <summary>
		/// Места: (доступно только для публичных страниц)
		/// </summary>
		public bool? Places
		{ get; set; }

		/// <summary>
		/// События: (доступно только для публичных страниц).
		/// </summary>
		public bool? Events
		{ get; set; }

		/// <summary>
		/// Ссылки: (доступно только для публичных страниц).
		/// </summary>
		public bool? Links
		{ get; set; }

		/// <summary>
		/// Дата основания компании, организации, 
		/// которой посвящена публичная страница в виде строки формата "dd.mm.YYYY". 
		/// </summary>
		public DateTime? PublicDate
		{ get; set; }

		/// <summary>
		/// Подкатегория публичной станицы.
		/// </summary>
		public ulong? PublicSubcategory
		{ get; set; }

		/// <summary>
		/// Категория публичной страницы.
		/// </summary>
		public ulong? PublicCategory
		{ get; set; }

		/// <summary>
		/// Идентификатор группы, которая является организатором события (только для событий).
		/// </summary>
		public ulong? EventGroupId
		{ get; set; }

		/// <summary>
		/// Дата окончания события.
		/// </summary>
		public DateTime? EventFinishDate { get; set; }

		/// <summary>
		/// Дата начала события.
		/// </summary>
		public DateTime? EventStartDate { get; set; }

		/// <summary>
		/// Адрес rss для импорта новостей 
		/// (доступен только группам, получившим соответствуюшее разрешение, 
		/// обратитесь в http://vk.com/support для получения разрешения).
		/// </summary>
		public string Rss
		{ get; set; }

		/// <summary>
		/// Номер телефона сообщества.
		/// </summary>
		public string Phone
		{ get; set; }

		/// <summary>
		/// Электронный адрес сообщества.
		/// </summary>
		public string Email
		{ get; set; }

		/// <summary>
		/// Короткое имя сообщества. 
		/// </summary>
		public string ScreenName
		{ get; set; }
		
		#endregion

		#region Методы

		/// <summary>
		/// Список тематик
		/// </summary>
		public readonly Dictionary<int, string> Subjects = new Dictionary<int, string>
		{
			{1, "Авто/мото "},
			{2, "Активный отдых "},
			{3, "Бизнес "},
			{4, "Домашние животные "},
			{5, "Здоровье "},
			{6, "Знакомство и общение "},
			{7, "Игры "},
			{8, "ИТ (компьютеры и софт) "},
			{9, "Кино "},
			{10, "Красота и мода "},
			{11, "Кулинария "},
			{12, "Культура и искусство "},
			{13, "Литература "},
			{14, "Мобильная связь и интернет "},
			{15, "Музыка "},
			{16, "Наука и техника "},
			{17, "Недвижимость "},
			{18, "Новости и СМИ "},
			{19, "Безопасность "},
			{20, "Образование "},
			{21, "Обустройство и ремонт "},
			{22, "Политика "},
			{23, "Продукты питания "},
			{24, "Промышленность "},
			{25, "Путешествия "},
			{26, "Работа "},
			{27, "Развлечения "},
			{28, "Религия "},
			{29, "Дом и семья "},
			{30, "Спорт "},
			{31, "Страхование "},
			{32, "Телевидение "},
			{33, "Товары и услуги "},
			{34, "Увлечения и хобби "},
			{35, "Финансы "},
			{36, "Фото "},
			{37, "Эзотерика "},
			{38, "Электроника и бытовая техника "},
			{39, "Эротика "},
			{40, "Юмор "},
			{41, "Общество, гуманитарные науки "},
			{42, "Дизайн и графика"}
		}; 
		/// <summary>
		/// Разобрать из JSON.
		/// </summary>
		/// <param name="response">Ответ от vk.</param>
		/// <returns></returns>
		internal static GroupInfo FromJson(VkResponse response)
		{
			var group = new GroupInfo();
			group.Title = response["title"];
			group.Description = response["description"];
			group.Address = response["address"];
			group.Place = response["place"];
			group.Wall = response["wall"];
			group.Photos = response["photos"];
			group.Video = response["video"];
			group.Audio = response["audio"];
			group.Docs = response["docs"];
			group.Topics = response["topics"];
			group.Wiki = response["wiki"];
			group.Access = response["access"];
			group.Subject = response["subject"];
			group.Website = response["website"];
			group.Contacts = response["contacts"];
			group.Places = response["places"];
			group.Events = response["events"];
			group.Links = response["links"];
			group.PublicDate = response["public_date"];
			group.PublicSubcategory = response["public_subcategory"];
			group.PublicCategory = response["public_category"];
			group.EventGroupId = response["event_group_id"];
			group.EventFinishDate = response["event_finish_date"];
			group.EventStartDate = response["event_start_date"];
			group.Rss = response["rss"];
			group.Phone = response["phone"];
			group.Email = response["email"];
			group.ScreenName = response["screen_name"];

			return group;
		}

		#endregion
	}
}