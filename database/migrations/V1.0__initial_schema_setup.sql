CREATE TABLE public.users (
    [id] SERIAL NOT NULL,
    [first_name] VARCHAR(255) NOT NULL,
    [last_name] VARCHAR(255) NOT NULL,
    [email] VARCHAR(255) NOT NULL,
    [password] VARCHAR(255) NOT NULL,
    CONSTRAINT users_pkey PRIMARY KEY (id)
);
CREATE TABLE public.users_games (
    [id] SERIAL NOT NULL,
    [user_id] SERIAL NOT NULL,
    [game_platform_id] SERIAL NOT NULL
);
CREATE TABLE public.reviews (
    [id] SERIAL NOT NULL,
    [star_rating] INT NOT NULL,
    [description] VARCHAR(255) NOT NULL,
    [date_reviewed] DATE NOT NULL,
    [game_id] INT NOT NULL CONSTRAINT reviews_game_platforms_game_platform_id_fk REFERENCES public.games_platforms,
    [user_id] INT NOT NULL CONSTRAINT reviews_users_user_id_fk REFERENCES public.users,
    CONSTRAINT reviews_pkey PRIMARY KEY (id)
);
CREATE TABLE public.completions (
    [id] SERIAL NOT NULL,
    [datetime] DATE NOT NULL,
    [user_game_id] INT NOT NULL CONSTRAINT completions_users_games_user_game_id_fk REFERENCES public.users_games,
    CONSTRAINT completions_pkey PRIMARY KEY (id)
);
CREATE TABLE public.platforms (
    [id] SERIAL NOT NULL,
    [name] VARCHAR(255),
    CONSTRAINT platforms_pkey PRIMARY KEY (id)
);
CREATE TABLE public.developers (
    [id] SERIAL NOT NULL,
    [name] VARCHAR(255)
);
CREATE TABLE public.games (
    [id] SERIAL NOT NULL,
    [name] VARCHAR(255),
    [description] VARCHAR(255),
    [developer_id] INT NOT NULL CONSTRAINT games_reviews_developer_id_fk REFERENCES public.developers,
    CONSTRAINT games_pkey PRIMARY KEY (id)
);
CREATE TABLE public.games_platforms (
    [id] SERIAL NOT NULL,
    [game_id] INT NOT NULL CONSTRAINT games_platforms_users_games_game_id_fk REFERENCES public.users_games,
    [platform_id] INT NOT NULL CONSTRAINT completions_platforms_platform_id_fk REFERENCES public.platforms,
    [release_date] DATE NOT NULL
);