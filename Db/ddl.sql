-- Data Definition Language DDL
CREATE TABLE roles (
  id INTEGER PRIMARY KEY AUTOINCREMENT,
  name VARCHAR(50) NOT NULL UNIQUE,
  description VARCHAR(100) NOT NULL,
  level INTEGER NOT NULL
);
-- 1,administrador,todopoderoso,1
-- 2,invitado,metiche,5

CREATE TABLE permissions (
  id INTEGER PRIMARY KEY AUTOINCREMENT,
  name VARCHAR(50) NOT NULL UNIQUE,
  description VARCHAR(100) NOT NULL
);
-- 1,login,puede iniciar sesion,1
-- 2,login,puede iniciar sesion,2
-- roles->permissions 1:N
-- permissions->roles N:1

CREATE TABLE roles_has_permissions (
  role_id INTEGER NOT NULL,
  permission_id INTEGER NOT NULL,
  PRIMARY KEY (role_id, permission_id)
);
-- 1,1
-- 1,2
-- 2,1
-- 2,2

CREATE TABLE users (
  id INTEGER PRIMARY KEY AUTOINCREMENT,
  name VARCHAR(16) NOT NULL UNIQUE,
  password VARCHAR(200) NOT NULL,
  firstname VARCHAR(50) NOT NULL,
  lastname VARCHAR(50) NOT NULL,
  email VARCHAR(200) NOT NULL UNIQUE,
  gender INTEGER NOT NULL,
  role_id INTEGER NOT NULL
);
-- users->roles N:1
-- roles->users 1:N