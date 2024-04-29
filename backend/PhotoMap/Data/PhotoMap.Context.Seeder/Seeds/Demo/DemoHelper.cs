namespace PhotoMap.Context.Seeder;

using PhotoMap.Context.Entities;

public class DemoHelper
{
    private PointCategory c1;
    private PointCategory c2;
    private PointCategory c3;
    private PointCategory c4;
    private PointCategory c5;
    private PointCategory c6;
    private PointCategory c7;
    private PointCategory c8;
    private PointCategory c9;
    private PointCategory c10;
    private PointCategory c11;
    private PointCategory c12;
    private PointCategory c13;

    public DemoHelper()
    {
        c1 = new PointCategory()
        {
            Title = "Собор"
        };
        c2 = new PointCategory()
        {
            Title = "Станция метро"
        };
        c3 = new PointCategory()
        {
            Title = "Университет"
        };
        c4 = new PointCategory()
        {
            Title = "Монастырь"
        };
        c5 = new PointCategory()
        {
            Title = "Театр"
        };
        c6 = new PointCategory()
        {
            Title = "Музей"
        };
        c7 = new PointCategory()
        {
            Title = "Площадь"
        };
        c8 = new PointCategory()
        {
            Title = "Мост"
        };
        c9 = new PointCategory()
        {
            Title = "Океанариум"
        };
        c10 = new PointCategory()
        {
            Title = "Памятник"
        };
        c11 = new PointCategory()
        {
            Title = "Парк"
        };
        c12 = new PointCategory()
        {
            Title = "Зоопарк"
        };
        c13 = new PointCategory()
        {
            Title = "Здание"
        };
    }
    public IEnumerable<PointCategory> GetPointCategories
    {
        get
        {
            return new List<PointCategory>
            {
                c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13
            };
        }
    }
    public IEnumerable<Point> GetPoints
    {
        get
        {
            return new List<Point>
                {
                    new Point()
                    {
                        Uid = Guid.NewGuid(),
                        Title = "Исаакиевский собор",
                        Description = "Хорошее место",
                        Latitude = 59.9343,
                        Longitude = 30.3351,
                        PointCategory = c1,
                        Feedbacks = new List<Feedback>()
                        {

                        },
                        ImagePathes = new List<ImagePath>()
                        {

                        }
                    },
                    new Point()
                    {
                        Uid = Guid.NewGuid(),
                        Title = "Китай город",
                        Description = "Станция метро в центре Москвы",
                        Latitude = 55.755508,
                        Longitude = 37.633173,
                        PointCategory = c2,
                        Feedbacks = new List<Feedback>()
                        {

                        },
                        ImagePathes = new List<ImagePath>()
                        {

                        }
                    },
                    new Point()
                    {
                        Uid = Guid.NewGuid(),
                        Title = "Воронежский государственный университет",
                        Description = "Воронежский государственный университет – крупнейший вуз Черноземья, культурный и исследовательский центр России, в состав которого входят 18 факультетов, филиал в г. Борисоглебск, 16 научно-исследовательских лабораторий, 10 учебно-научно-производственных центров, Зональная научная библиотека, содержащая более 3-х миллионов единиц хранения.",
                        Latitude = 51.656759575204795,
                        Longitude = 39.20585989952088,
                        PointCategory = c3,
                        Feedbacks = new List<Feedback>()
                        {
                            new Feedback()
                            {
                                Title = "Отличный универ",
                                Rating = 5,
                                FeedbackAuthor = "user1@photomap.com"
                            }
                        },
                        ImagePathes = new List<ImagePath>()
                        {
                            new ImagePath()
                            {
                                Title =  "https://firebasestorage.googleapis.com/v0/b/photomap-5496a.appspot.com/o/images%2F5mglHeWubLY.jpg?alt=media&token=31340309-c03c-4c7d-9452-ce3eff1acc82"
                            }
                        }
                    },
                    new Point()
                    {
                        Uid = Guid.NewGuid(),
                        Title = "Алексеево-Акатов монастырь",
                        Description = "Алексеево-Акатов монастырь — один из крупнейших в Воронежской области — был основан, предположительно, в 1620 году. Поводом для основания обители стала победа над литовцами и черкасами, пытавшимися захватить воронежские земли.",
                        Latitude = 51.67489671808114,
                        Longitude = 39.22338008880616,
                        PointCategory = c4,
                        Feedbacks = new List<Feedback>(),
                        ImagePathes = new List<ImagePath>()
                        {
                            new ImagePath()
                            {
                                Title =  "https://firebasestorage.googleapis.com/v0/b/photomap-5496a.appspot.com/o/images%2Fscale_2400.jpg?alt=media&token=8b37fb20-7cb7-4162-a1a2-1a6f1e45973c"
                            }
                        }
                    },
                    new Point()
                    {
                        Uid = Guid.NewGuid(),
                        Title = "Благовещенский кафедральный собор",
                        Description = "Кафедральный собор Благовещения Пресвятой Богородицы считается третьим по величине храмом в России и одним из самых высоких православных храмов мира. Наивысшей отметки в 97 метров над уровнем земли достигает крест, установленный на шпиле колокольни.",
                        Latitude = 51.67623357491506,
                        Longitude = 39.2103123664856,
                        PointCategory = c1,
                        Feedbacks = new List<Feedback>(),
                        ImagePathes = new List<ImagePath>()
                        {
                            new ImagePath()
                            {
                                Title = "https://firebasestorage.googleapis.com/v0/b/photomap-5496a.appspot.com/o/images%2Fscale_2400%20(1).jpg?alt=media&token=1d4d133c-c600-4a32-983c-d09dc46c9395"
                            }
                        }
                    },
                    new Point()
                    {
                        Uid = Guid.NewGuid(),
                        Title = "Воронежский театр оперы и балета",
                        Description = "Формально история Воронежского театра оперы и балета началась в 1931 году, но официально он был основан в 1968. Специально для этого было выстроено новое здание театра, украсившее собой площадь Ленина. За время существования театр оперы и балета успел порадовать зрителей сотнями, а может быть и тысячами постановок по произведениям классиков и наших современников.",
                        Latitude = 51.66150185430492,
                        Longitude = 39.19907927513123,
                        PointCategory = c5,
                        Feedbacks = new List<Feedback>(),
                        ImagePathes = new List<ImagePath>()
                        {
                            new ImagePath()
                            {
                                Title = "https://firebasestorage.googleapis.com/v0/b/photomap-5496a.appspot.com/o/images%2Fscale_2400%20(2).jpg?alt=media&token=abfd0a03-ebf4-4575-b57a-9b3323ae7908"
                            }
                        }
                    },
                    new Point()
                    {
                        Uid = Guid.NewGuid(),
                        Title = "Корабль-музей «Гото-Предестинация»",
                        Description = "Судно представляет собой современную копию реально существовавшего корабля, который стоял на вооружении российского флота в петровские времена. «Гото Предестинация» является не только украшением Адмиралтейской площади, но и действующим музеем, где вы сможете изнутри увидеть как устроен корабль XVIII века.",
                        Latitude = 51.655931140050036,
                        Longitude = 39.215971827507026,
                        PointCategory = c6,
                        Feedbacks = new List<Feedback>(),
                        ImagePathes = new List<ImagePath>()
                        {
                            new ImagePath()
                            {
                                Title = "https://firebasestorage.googleapis.com/v0/b/photomap-5496a.appspot.com/o/images%2Fscale_2400%20(3).jpg?alt=media&token=a63ebf15-3241-458f-aadc-f670387711a0"
                            }
                        }
                    },
                    new Point()
                    {
                        Uid = Guid.NewGuid(),
                        Title = "Адмиралтейская площадь",
                        Description = "Площадь торжественно открылась она осенью 1996 года, когда Воронежу исполнилось 410 лет, а Военно-морскому флоту России ровно 300.",
                        Latitude = 51.657468229750734,
                        Longitude = 39.21565532684327,
                        PointCategory = c7,
                        Feedbacks = new List<Feedback>(),
                        ImagePathes = new List<ImagePath>() { new ImagePath() { Title = "https://firebasestorage.googleapis.com/v0/b/photomap-5496a.appspot.com/o/images%2Fscale_2400%20(4).jpg?alt=media&token=cd5f826a-ab97-4de2-9d4b-47865e0212a5" } }
                    },
                    new Point()
                    {
                        Uid = Guid.NewGuid(),
                        Title = "Воронежский областной краеведческий музей",
                        Description = "Кем и когда был основан Воронеж? Какую роль сыграл город в становлении Военно-морского флота России? Какие важные исторические события разворачивались на воронежской земле? — На эти и многие другие вопросы вы получите ответы в Воронежском областном краеведческом музее. Он ведет свою историю с конца XIX века, поэтому различных экспозиций здесь накопилось достаточно.",
                        Latitude = 51.66670256609953,
                        Longitude = 39.19342517852784,
                        PointCategory = c6,
                        Feedbacks = new List<Feedback>(),
                        ImagePathes = new List<ImagePath>()
                        {
                            new ImagePath()
                            {
                                Title = "https://firebasestorage.googleapis.com/v0/b/photomap-5496a.appspot.com/o/images%2Fscale_2400%20(5).jpg?alt=media&token=776ac518-f012-450b-9272-a500c3c03482"
                            }
                        }
                    },
                    new Point()
                    {
                        Uid = Guid.NewGuid(),
                        Title = "Воронежский областной художественный музей им. И. Н. Крамского",
                        Description = "Одно из самых значимых собраний произведений искусства в России находится в художественном музее Воронежа, названном в честь Ивана Крамского — выдающегося русского живописца. Впервые двери учреждения открылись для широкой публики в начале 1930-х, а основу экспозиции составили реквизированные произведения искусства и доставленные из других российских музеев экспонаты. Всего в музее присутствуют несколько выставок, которые посвящены не только русскому искусству, но и зарубежному.",
                        Latitude = 51.67373572050426,
                        Longitude = 39.209733009338386,
                        PointCategory = c6,
                        Feedbacks = new List<Feedback>(),
                        ImagePathes = new List<ImagePath>()
                        {
                            new ImagePath()
                            {
                                Title = "https://firebasestorage.googleapis.com/v0/b/photomap-5496a.appspot.com/o/images%2Fscale_2400%20(6).jpg?alt=media&token=a17e5c69-f079-4a53-9d6c-6500266c7082"
                            }
                        }
                    },
                    new Point()
                    {
                        Uid = Guid.NewGuid(),
                        Title = "Музей «Арсенал»",
                        Description = "«Арсенал» — один из филиалов краеведческого музея, посвященный различным видам вооружения. Изначально это здание, построенное ещё в XVIII веке, принадлежало суконной фабрике. Затем здесь размещалась школа кантонистов, где обучали солдатских детей, по происхождению обязанных впоследствии тоже поступить на военную службу.",
                        Latitude = 51.672874101344696,
                        Longitude = 39.215735793113716,
                        PointCategory = c6,
                        Feedbacks = new List<Feedback>(),
                        ImagePathes = new List<ImagePath>()
                        {
                            new ImagePath()
                            {
                                Title = "https://firebasestorage.googleapis.com/v0/b/photomap-5496a.appspot.com/o/images%2Fscale_2400%20(7).jpg?alt=media&token=3e234668-e328-40d4-9a1b-2b9f6479780f"
                            }
                        }
                    },
                    new Point()
                    {
                        Uid = Guid.NewGuid(),
                        Title = "Каменный мост",
                        Description = "Этот каменный мост был возведен почти 200 лет назад, но до сих пор стоит и продолжает выполнять важную роль в транспортной системе города. Его длина составляет всего 10 метров, но значимость в культурном и историческом плане куда более грандиозна. Среди жителей Воронежа за прошедшие годы сложилось множество традиций, связанных с мостом на улице Карла Маркса. Самая популярная из них закрепилась у молодоженов: в день свадьбы нужно разбить об мост бутылку шампанского, дабы брак был крепким и долгим.",
                        Latitude = 51.6611258360065,
                        Longitude = 39.207581877708435,
                        PointCategory = c8,
                        Feedbacks = new List<Feedback>(),
                        ImagePathes = new List<ImagePath>()
                        {
                            new ImagePath()
                            {
                                Title = "https://firebasestorage.googleapis.com/v0/b/photomap-5496a.appspot.com/o/images%2Fscale_2400%20(8).jpg?alt=media&token=a7866fa8-6989-4199-bb44-9a69c9d5171e"
                            }
                        }
                    },
                    new Point()
                    {
                        Uid = Guid.NewGuid(),
                        Title = "Воронежский академический театр драмы им. А. Кольцова",
                        Description = "Воронежский академический театр драмы им. А. Кольцова — это культурный символ Воронежа, входящий в число ведущих драматических театров России. Основанный в 1787 году, он считается одним из старейших театров страны и на протяжении всего своего существования остается местом, где над созданием спектаклей трудятся лучшие актеры, режиссеры и драматурги.",
                        Latitude = 51.6638306857368,
                        Longitude = 39.204744100570686,
                        PointCategory = c5,
                        Feedbacks = new List<Feedback>(),
                        ImagePathes = new List<ImagePath>()
                        {
                            new ImagePath()
                            {
                                Title = "https://firebasestorage.googleapis.com/v0/b/photomap-5496a.appspot.com/o/images%2Fscale_2400%20(9).jpg?alt=media&token=6654df22-a415-46f5-b544-5ebc0c8211ff"
                            }
                        }
                    },
                    new Point()
                    {
                        Uid = Guid.NewGuid(),
                        Title = "Воронежский океанариум",
                        Description = "Морские глубины интересовали и продолжают интересовать человека, ведь мы до сих пор не знаем обо всём, что скрывается под толщей воды. Однако давайте оставим исследование морей и океанов профессионалам, а сами взглянем на то, что уже известно.",
                        Latitude = 51.79063345882765,
                        Longitude = 39.20657873153687,
                        PointCategory = c9,
                        Feedbacks = new List<Feedback>(),
                        ImagePathes = new List<ImagePath>()
                        {
                            new ImagePath()
                            {
                                Title = "https://firebasestorage.googleapis.com/v0/b/photomap-5496a.appspot.com/o/images%2Fscale_2400%20(10).jpg?alt=media&token=74d97744-3c20-4b70-a342-f7983907f032"
                            }
                        }
                    },
                    new Point()
                    {
                        Uid = Guid.NewGuid(),
                        Title = "Театр кукол «Шут»",
                        Description = "Воронежский театр кукол «Шут» зародился в 1925 году в качестве любительского коллектива, но очень быстро перерос в профессиональный. Ещё быстрее была завоевана любовь зрителей, потому что каждый новый спектакль неизменно собирал полные залы. Театр «Шут» является лауреатом множества премий, а в его репертуаре найдутся постановки как для детей, так и для взрослых",
                        Latitude = 51.666133611358454,
                        Longitude = 39.20467972755433,
                        PointCategory = c5,
                        Feedbacks = new List<Feedback>(),
                        ImagePathes = new List<ImagePath>()
                    },
                    new Point()
                    {
                        Uid = Guid.NewGuid(),
                        Title = "Памятник Белому Биму",
                        Description = "Не забудьте погладить Белого Бима Черное ухо — памятник персонажу одноименной повести Г. Н. Троепольского, установленный неподалеку.",
                        Latitude = 51.66608370270697,
                        Longitude = 39.20546829700471,
                        PointCategory = c10,
                        Feedbacks = new List<Feedback>(),
                        ImagePathes = new List<ImagePath>()
                        {
                            new ImagePath()
                            {
                                Title = "https://firebasestorage.googleapis.com/v0/b/photomap-5496a.appspot.com/o/images%2Fscale_2400%20(11).jpg?alt=media&token=2c5b6b14-3df8-47cf-a6a0-268f062c5415"
                            }
                        }
                    },
                    new Point()
                    {
                        Uid = Guid.NewGuid(),
                        Title = "Котёнок с улицы Лизюкова",
                        Description = "Вы наверняка помните старый советский мультфильм о котенке Василии, жившем в Воронеже на улице Лизюкова. Устав бегать от собак, он пожелал стать сильным зверем, в чем ему и помогла сидевшая на ветке ворона. Сказав волшебное слово, она превратила котенка в бегемота и отправила в Африку, откуда ему предстояло вернуться в родной город. Воронеж вовсе не случайно фигурировал в сюжете, ведь сценарий для «Котёнка с улицы Лизюкова» написал В. Злотников — коренной воронежец. Мультфильм быстро обрел популярность по всему Союзу, но больше всего он полюбился именно жителям Воронежа. В 2003 же рядом с бывшим кинотеатром «Мир» установили памятник, где Василий, сидя на дереве, общается с той самой хитроумной вороной.",
                        Latitude = 51.706800854979036,
                        Longitude = 39.172310829162605,
                        PointCategory = c10,
                        Feedbacks = new List<Feedback>(),
                        ImagePathes = new List<ImagePath>()
                        {
                            new ImagePath()
                            {
                                Title = "https://firebasestorage.googleapis.com/v0/b/photomap-5496a.appspot.com/o/images%2Fscale_2400%20(12).jpg?alt=media&token=09af7579-1d85-48b6-920c-5db78ca8ea5d"

                            }
                        }
                    },
                    new Point()
                    {
                        Uid = Guid.NewGuid(),
                        Title = "Площадь победы",
                        Description = "Площадь Победы — это важнейшее для всех воронежцев место, так как в годы Великой Отечественной войны город оказался одним из эпицентров боевых действий. Сотни тысяч советских солдат погибли на воронежской земле, а бои в городе шли за каждый квартал, каждую улицу, каждый дом. Велись боевые действия и на площади Победы, где сегодня, благодаря подвигу предков, гуляют семьи, встречаются влюбленные и слышен детский смех. Эта площадь и расположенный на ней мемориальный комплекс посвящены всем тем, кто не пожалел жизни ради освобождения города и остальных советских земель. Доминантой мемориала является 40-метровая стела с орденом Отечественной войны I степени, коим наградили Воронеж за героизм его защитников.",
                        Latitude = 51.67150304517444,
                        Longitude = 39.211074113845825,
                        PointCategory = c7,
                        Feedbacks = new List<Feedback>(),
                        ImagePathes = new List<ImagePath>()
                        {
                            new ImagePath()
                            {
                                Title = "https://firebasestorage.googleapis.com/v0/b/photomap-5496a.appspot.com/o/images%2Fscale_2400%20(13).jpg?alt=media&token=dd48374f-a2be-4e0c-9ddf-3d8b61f8ccb8"

                            }
                        }
                    },
                    new Point()
                    {
                        Uid = Guid.NewGuid(),
                        Title = "Памятник «Ротонда»",
                        Description = "В 1940 году в Воронеже возвели новое здание клинической больницы, в ансамбле которого особенно выделялся учебный корпус, выстроенный в форме ротонды. Как вы уже успели догадаться, просуществовала больница недолго и была разрушена в ходе боев за Воронеж. В послевоенные годы денег на восстановление постройки не было, поэтому её развалины так и стояли, подвергаясь ещё большим разрушениям. По итогу было принято решение законсервировать руины учебного корпуса и сохранить их в качестве памятника, ныне являющегося живым свидетелем кровопролитных боев 1942—1943 годов.",
                        Latitude = 51.693654844721166,
                        Longitude = 39.20891761779786,
                        PointCategory = c10,
                        Feedbacks = new List<Feedback>(),
                        ImagePathes = new List<ImagePath>()
                        {
                            new ImagePath()
                            {
                                Title = "https://firebasestorage.googleapis.com/v0/b/photomap-5496a.appspot.com/o/images%2Fscale_2400%20(14).jpg?alt=media&token=87b816ca-b31f-4963-81df-2d6163752bf4"

                            }
                        }
                    },
                    new Point()
                    {
                        Uid = Guid.NewGuid(),
                        Title = "Парк «Алые паруса»",
                        Description = "Парк «Алые паруса», который через пару лет отметит 50-летний юбилей, занимает особенное место в сердцах местных жителей. Полюбился он благодаря обширной сосновой роще — уголку живой природы посреди бетонных джунглей города. Располагается она на берегу Воронежского водохранилища, вместе с которым создает удивительной красоты пейзаж.",
                        Latitude = 51.658390874523825,
                        Longitude = 39.24101829528809,
                        PointCategory = c11,
                        Feedbacks = new List<Feedback>(),
                        ImagePathes = new List<ImagePath>()
                        {
                            new ImagePath()
                            {
                                Title = "https://firebasestorage.googleapis.com/v0/b/photomap-5496a.appspot.com/o/images%2Fscale_2400%20(15).jpg?alt=media&token=d25df859-965e-48ed-815e-7839f46088d6"

                            },
                            new ImagePath()
                            {
                                Title = "https://firebasestorage.googleapis.com/v0/b/photomap-5496a.appspot.com/o/images%2Fscale_2400%20(16).jpg?alt=media&token=9880d774-a7a1-458a-9584-2c9636a17c48"

                            }

                        }
                    },
                    new Point()
                    {
                        Uid = Guid.NewGuid(),
                        Title = "Храм Ксении Петербургской",
                        Description = "В 1940-е годы на том месте, где сейчас стоит храм Ксении Петербургской, располагалась так называемая «Роща сердца». Так её нарекли из-за характерной формы, коей рощу обозначали на оперативно-тактических картах в годы войны. Солдаты же между собой называли это место «Рощей смерти», так как именно в этом районе велись одни из самых ожесточенных боев. Уже в девяностые годы здесь началось возведение храмового комплекса во имя блаженной Ксении Петербургской, дабы почтить память всех усопших. В состав комплекса входит, собственно, сам храм Ксении Петербургской, небольшая церковь во имя покровителя всех воинов князя Александра Невского и часовня, посвященная праведному Иоанну Кронштадтскому.",
                        Latitude = 51.716817800989794,
                        Longitude = 39.17263269424439,
                        PointCategory = c1,
                        Feedbacks = new List<Feedback>(),
                        ImagePathes = new List<ImagePath>()
                        {
                            new ImagePath()
                            {
                                Title = "https://firebasestorage.googleapis.com/v0/b/photomap-5496a.appspot.com/o/images%2Fscale_2400%20(17).jpg?alt=media&token=dcc0fdc6-03f6-44c3-a9fa-4935a0e0195c"
                            }
                        }
                    },
                    new Point()
                    {
                        Uid = Guid.NewGuid(),
                        Title = "Зоопарк",
                        Description = "Начинался Воронежский зоопарк с небольшого зала, но к сегодняшнему дню разросся до куда больших размеров. По последним данным здесь обитает свыше 200 видов животных общей численностью более одной тысячи особей. Увидеть в вольерах и клетках можно самых разных представителей животного мира, начиная с хомячков и сусликов, заканчивая львами, медведями и тиграми. Также представлены различные виды птиц, рептилий, земноводных, рыб и насекомых, обитающих в отдельной зоне. Богатую фауну дополняет и не менее богатая флора, так как на территории Воронежского зоопарка произрастают экзотические виды растений, вроде банановой травы, кофейного дерева, лимона и т. д.",
                        Latitude = 51.64040548428008,
                        Longitude = 39.24254179000855,
                        PointCategory = c12,
                        Feedbacks = new List<Feedback>(),
                        ImagePathes = new List<ImagePath>()
                        {
                            new ImagePath()
                            {
                                Title =  "https://firebasestorage.googleapis.com/v0/b/photomap-5496a.appspot.com/o/images%2Fscale_2400%20(18).jpg?alt=media&token=fe46b8aa-7d64-49cb-b5db-648568609733"
                        
                            }
                        }
                    },
                    new Point()
                    {
                        Uid = Guid.NewGuid(),
                        Title = "Покровский собор",
                        Description = "Строительство каменного собора датируется уже началом XVIII века, а вот его реконструкции и возведение новых пристроек продолжались вплоть до середины XIX столетия.",
                        Latitude = 51.6650618109799,
                        Longitude = 39.21305894851685,
                        PointCategory = c1,
                        Feedbacks = new List<Feedback>(),
                        ImagePathes = new List<ImagePath>()
                        {
                            new ImagePath()
                            {
                                Title = "https://firebasestorage.googleapis.com/v0/b/photomap-5496a.appspot.com/o/images%2Fscale_2400%20(19).jpg?alt=media&token=5a506f58-1166-4904-a181-dbdd63125237"
                            }
                        }
                    },
                    new Point()
                    {
                        Uid = Guid.NewGuid(),
                        Title = "Казанский храм",
                        Description = "С основанием Казанского храма связана легенда, отсылающая нас к началу XX века. Тогда в поселении Отрожка, которое ныне является микрорайоном Воронежа, у некоторых жителей возникали видения образа Казанской иконы. Происходило это зачастую на одном и том же месте, поэтому данное явление истолковали как божью волю и в 1903 году начали строительство храма Казанской иконы Божией матери. Спустя 8 лет церковь завершили, освятили и провели внутри первое богослужение. После закрытия храма в советские годы вывозом ценностей не ограничились, так как здание лишилось окон и даже деревянных полов. Свой вклад в разрушение святыни сделала и война, но в 1946 году Казанский храм, ввиду неоднократных просьб со стороны верующих, открылся вновь. После этого удалось начать реставрацию архитектурного памятника, благодаря чему мы можем любоваться им и сегодня.",
                        Latitude = 51.699991854716544,
                        Longitude = 39.268902540206916,
                        PointCategory = c1,
                        Feedbacks = new List<Feedback>(),
                        ImagePathes = new List<ImagePath>()
                        {
                            new ImagePath()
                            {
                                Title = "https://firebasestorage.googleapis.com/v0/b/photomap-5496a.appspot.com/o/images%2Fscale_2400%20(21).jpg?alt=media&token=0fccf446-39ff-40a3-9ea0-bda50e9ce03f"
                            }
                        }
                    },
                    new Point()
                    {
                        Uid = Guid.NewGuid(),
                        Title = "Музей-диорама",
                        Description = "В Музее-диораме находится уникальный экспонат, который, как вы уже догадались, представляет собой 6-метровую диораму — миниатюрную модель, иллюстрирующую момент из битвы на Чижовском плацдарме. Бои за эту территорию были очень кровопролитными и столь же важными, так как отсюда советские войска пошли в контрнаступление и освободили Воронеж. Несмотря на название, диорама — это далеко не единственный экспонат музея, ведь уже на подходе вас ожидает выставка военной техники, принимавшей участие в Великой Отечественной войне. Внутри расположена не менее интересная экспозиция, включающая советские и немецкие документы, фотографии, униформу, оружие, ордена, миниатюрные модели техники и даже произведения искусства на военную тематику.",
                        Latitude = 51.659351769534645,
                        Longitude = 39.24765944480897,
                        PointCategory = c6,
                        Feedbacks = new List<Feedback>(),
                        ImagePathes = new List<ImagePath>()
                        {
                            new ImagePath()
                            {
                                Title = "https://firebasestorage.googleapis.com/v0/b/photomap-5496a.appspot.com/o/images%2Fscale_2400%20(22).jpg?alt=media&token=e8dc7f10-be76-4253-9438-44ab7a486a05"

                            },
                            new ImagePath()
                            {
                                Title = "https://firebasestorage.googleapis.com/v0/b/photomap-5496a.appspot.com/o/images%2Fscale_2400%20(23).jpg?alt=media&token=699bd409-2564-45eb-820a-dd22a6782dde"
                            }

                        }
                    },
                    new Point()
                    {
                        Uid = Guid.NewGuid(),
                        Title = "Мемориальный комплекс «Чижовский плацдарм»",
                        Description = "Чижовский плацдарм носил стратегически важное значение в битве за Воронеж и последующем освобождении оккупированных территорий. Первые бои здесь развернулись осенью 1942 года и продолжались долгих 204 дня, пока город наконец не был освобожден. Бои за Чижовку вошли в историю как пример мужества и стойкости советских защитников, ведь бойцам приходилось отражать атаки превосходящего по силе и численности противника. В 30-летнюю годовщину Победы в Великой Отечественной войне на территории Чижовского плацдарма начали строительство одноименного мемориального комплекса, который торжественно открыли уже в 1985 году. В состав комплекса входит «Зал Памяти» с именами защитников Воронежа и скульптурная композиция с тремя солдатами, салютующими погибшим товарищам.",
                        Latitude = 51.641282285623404,
                        Longitude = 39.20307040214539,
                        PointCategory = c10,
                        Feedbacks = new List<Feedback>(),
                        ImagePathes = new List<ImagePath>()
                        {
                            new ImagePath()
                            {
                                Title = "https://firebasestorage.googleapis.com/v0/b/photomap-5496a.appspot.com/o/images%2Fscale_2400%20(24).jpg?alt=media&token=a33b1d02-1089-46ab-993a-2c28d5b1ff25"
                            }
                        }
                    },
                    new Point()
                    {
                        Uid = Guid.NewGuid(),
                        Title = "Здание гостиницы «Бристоль»",
                        Description = "Четырехэтажное здание гостиницы «Бристоль» украсило проспект Революции, а тогда — Большую Дворянскую улицу, в 1910 году. Возвели здание в популярном в начале XX века стиле модерн, который прошел проверку временем и ныне ценится всеми почитателями старинной архитектуры. При строительстве были использованы новейшие инженерные технологии, а один из первых грузовых лифтов в Воронеже появился именно здесь. С того момента «Бристоль» практически не поменялась и сохранила всю красоту экстерьера и интерьера, которые сегодня смотрятся всё так же свежо и ново. Снять номер здесь уже нельзя, так как внутренние помещения заняты магазинами, кофейнями и офисами, но красота архитектурного памятника от этого никуда не улетучилась.",
                        Latitude = 51.666270028058705,
                        Longitude = 39.206294417381294,
                        PointCategory = c13,
                        Feedbacks = new List<Feedback>(),
                        ImagePathes = new List<ImagePath>()
                        {
                            new ImagePath()
                            {
                                Title = "https://firebasestorage.googleapis.com/v0/b/photomap-5496a.appspot.com/o/images%2Fscale_2400%20(25).jpg?alt=media&token=8f46194d-9ffc-4f84-ba6e-cc45b4c69300"
                            }
                        }
                    },
                    new Point()
                    {
                        Uid = Guid.NewGuid(),
                        Title = "Бульвар Дружбы",
                        Description = "Улица Бульвар Дружбы в Старом Осколе",
                        Latitude = 51.28706332801568,
                        Longitude = 37.802742719650276,
                        PointCategory = c7,
                        Feedbacks = new List<Feedback>(),
                        ImagePathes = new List<ImagePath>()
                    },
                    new Point()
                    {
                        Uid = Guid.NewGuid(),
                        Title = "Атаманский лес",
                        Description = "Одним из самых старых и известных памятников Старого Оскола является братская могила № 31 советских воинов, погибших в боях с фашистскими захватчиками, расположенная на юго-западной окраине города, у Атаманского леса (1943 г.). Это самая большая братская могила на Белгородчине. Здесь покоятся около 2000 человек.",
                        Latitude = 51.264264584584076,
                        Longitude = 37.81270980834962,
                        PointCategory = c6,
                        Feedbacks = new List<Feedback>(),
                        ImagePathes = new List<ImagePath>()
                    },
                    new Point()
                    {
                        Uid = Guid.NewGuid(),
                        Title = "Памятник Георгию Жукову",
                        Description = "Памятник Георгию Жукову — памятник-бюст, расположенный на площади Победы в центре города Старый Оскол Белгородской области. Торжественно открыт в 1988 году, изготовлен на средства ветеранов Великой Отечественной войны.",
                        Latitude = 51.3083350225614,
                        Longitude = 37.89053678512574,
                        PointCategory = c10,
                        Feedbacks = new List<Feedback>(),
                        ImagePathes = new List<ImagePath>()
                    },
                };
        }
    }
}