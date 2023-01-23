insert into developers ([name]) values ('Naughty Dog');
insert into developers ([name]) values ('Santa Monica Studios');
insert into developers ([name]) values ('FromSoftware');

insert into games ([name], [description], [developer_id]) values ('God of War', 'His vengeance against the Gods of Olympus years behind him, Kratos now lives as a man in the realm of Norse Gods and monsters.' , (select id from developers where [name] ='Santa Monica Studios'))
insert into games ([name], [description], [developer_id]) values ('God of War Ragnarok', 'Embark on an epic and heartfelt journey as Kratos and Atreus struggle with holding on and letting go.' , (select id from developers where [name] ='Santa Monica Studios'))
insert into games ([name], [description], [developer_id]) values ('Uncharted 4', 'Several years after his last adventure, retired fortune hunter Nathan Drake, is forced back into the world of thieves.' , (select id from developers where [name] ='Naughty Dog'))
insert into games ([name], [description], [developer_id]) values ('Elden Ring', 'In the Lands Between ruled by Queen Marika the Eternal, the Elden Ring, the source of the Erdtree, has been shattered.' , (select id from developers where [name] ='Naughty Dog'))

insert into platforms ([name]) values ('Playstation 4');
insert into platforms ([name]) values ('Playstation 5');
insert into platforms ([name]) values ('Microsoft Windows');

insert into users ([first_name], [last_name], [email], [password]) values ('Campbell', 'Gilpin', 'campbell.gilpin@unosquare.com', 'Password123');

insert into games_platforms([game_id], [platform_id], [release_date]) values ((select id from games where [name] ='God of War Ragnarok'), (select id from platforms where [name] ='Playstation 5'), '2022-11-09')
insert into games_platforms([game_id], [platform_id], [release_date]) values ((select id from games where [name] ='God of War Ragnarok'), (select id from platforms where [name] ='Playstation 4'), '2022-11-09')
insert into games_platforms([game_id], [platform_id], [release_date]) values ((select id from games where [name] ='God of War'), (select id from platforms where [name] ='Playstation 4'), '2018-04-20')
insert into games_platforms([game_id], [platform_id], [release_date]) values ((select id from games where [name] ='God of War'), (select id from platforms where [name] ='Microsoft Windows'), '2022-01-14')
insert into games_platforms([game_id], [platform_id], [release_date]) values ((select id from games where [name] ='Elden Ring'), (select id from platforms where [name] ='Playstation 4'), '2022-02-25')
insert into games_platforms([game_id], [platform_id], [release_date]) values ((select id from games where [name] ='Elden Ring'), (select id from platforms where [name] ='Playstation 5'), '2022-02-25')
insert into games_platforms([game_id], [platform_id], [release_date]) values ((select id from games where [name] ='Elden Ring'), (select id from platforms where [name] ='Microsoft Windows'), '2022-02-25')
insert into games_platforms([game_id], [platform_id], [release_date]) values ((select id from games where [name] ='Uncharted 4'), (select id from platforms where [name] ='Playstation 4'), '2016-05-10')
insert into games_platforms([game_id], [platform_id], [release_date]) values ((select id from games where [name] ='Uncharted 4'), (select id from platforms where [name] ='Microsoft Windows'), '2022-10-19')

insert into users_games ([user_id], [game_platform_id]) values ((select id from users where [first_name] ='Campbell'), (select id from games_platforms where [game_id] = (select id from games where [name] ='God of War Ragnarok') AND [platform_id] = (select id from platforms where [name] ='Playstation 5')))
insert into users_games ([user_id], [game_platform_id]) values ((select id from users where [first_name] ='Campbell'), (select id from games_platforms where [game_id] = (select id from games where [name] ='God of War') AND [platform_id] = (select id from platforms where [name] ='Playstation 4')))
insert into users_games ([user_id], [game_platform_id]) values ((select id from users where [first_name] ='Campbell'), (select id from games_platforms where [game_id] = (select id from games where [name] ='Elden Ring') AND [platform_id] = (select id from platforms where [name] ='Playstation 5')))
insert into users_games ([user_id], [game_platform_id]) values ((select id from users where [first_name] ='Campbell'), (select id from games_platforms where [game_id] = (select id from games where [name] ='Uncharted 4') AND [platform_id] = (select id from platforms where [name] ='Playstation 4')))

insert into completions ([datetime], [user_game_id]) values ('2023-01-02', (select id from users_games where [user_id] = (select id from users where [first_name] ='Campbell') AND [game_platform_id] = (select id from games_platforms where [game_id] = (select id from games where [name] ='God of War Ragnarok') AND [platform_id] = (select id from platforms where [name] ='Playstation 5'))))

insert into reviews ([star_rating], [description], [date_reviewed], [game_id], [user_id]) values (5, 'Good stuff!', '2023-01-23', (select id from games where [name] ='God of War Ragnarok'), (select id from users where [first_name] ='Campbell'))