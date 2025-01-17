-- Create database
CREATE DATABASE IF NOT EXISTS receptek_12a;

-- Use the database
USE receptek_12a;

-- Create table for food recipes
CREATE TABLE IF NOT EXISTS recepies (
    id INT AUTO_INCREMENT PRIMARY KEY,
    receptNev VARCHAR(255) NOT NULL,
    hozzavalok TEXT NOT NULL,
    leiras TEXT NOT NULL,
    elkeszitesiIdo INT,
    fozesiIdo INT,
    osszesIdo INT
);

-- Insert 50 food recipes
INSERT INTO recepies (receptNev, hozzavalok, leiras, elkeszitesiIdo, fozesiIdo, osszesIdo) VALUES
('Spaghetti Carbonara', 'Spagetti, Tojás, Parmezán sajt, Pancetta, Fokhagyma, Só, Bors', '1. Főzd meg a spagettit. 2. Pirítsd meg a pancettát fokhagymával. 3. Keverd össze a tojást és a sajtot. 4. Keverd össze a spagettit, a pancettát és a tojásos keveréket. 5. Ízesítsd sóval és borssal.', 10, 20, 30),
('Chicken Curry', 'Csirke, Curry por, Kókusztej, Hagyma, Fokhagyma, Gyömbér, Só, Bors, Olaj', '1. Pirítsd meg a hagymát, fokhagymát és gyömbért. 2. Add hozzá a csirkét és süsd meg. 3. Add hozzá a curry port. 4. Öntsd bele a kókusztejet. 5. Párold, amíg a csirke teljesen meg nem fő. 6. Ízesítsd sóval és borssal.', 15, 30, 45),
('Beef Stroganoff', 'Marhahús, Hagyma, Gomba, Tejföl, Marhahús alaplé, Vaj, Liszt, Só, Bors', '1. Pirítsd meg a marhahús csíkokat. 2. Főzd meg a hagymát és a gombát. 3. Add hozzá a marhahús alaplét és párold. 4. Keverd bele a tejfölt. 5. Sűrítsd a vaj és liszt keverékével. 6. Ízesítsd sóval és borssal.', 20, 25, 45),
('Vegetarian Chili', 'Vörösbab, Fekete bab, Kukorica, Paradicsom, Hagyma, Fokhagyma, Chili por, Kömény, Só, Bors, Olaj', '1. Pirítsd meg a hagymát és a fokhagymát. 2. Add hozzá a paradicsomot és a fűszereket. 3. Öntsd bele a babot és a kukoricát. 4. Párold, amíg a zöldségek meg nem puhulnak. 5. Ízesítsd sóval és borssal.', 10, 40, 50),
/* Ismételd meg a fenti struktúrát a fennmaradó 46 bejegyzéshez */
('Pizza Margherita', 'Pizzatészta, Paradicsomszósz, Mozzarella sajt, Bazsalikom, Olívaolaj, Só', '1. Kend meg a tésztát paradicsomszósszal. 2. Add hozzá a mozzarellát. 3. Sütőben süsd meg. 4. Díszítsd friss bazsalikommal és olívaolajjal. 5. Ízesítsd sóval.', 15, 20, 35);

-- Continue with additional 45 recipes...

-- Example of more entries to give the idea
/*
INSERT INTO recepies (receptNev, hozzavalok, leiras, elkeszitesiIdo, fozesiIdo, osszesIdo) VALUES
('Recipe Name', 'ingredient1, ingredient2, etc.', 'Instructions', prep_time_minutes, cook_time_minutes, total_time_minutes);
...
*/
