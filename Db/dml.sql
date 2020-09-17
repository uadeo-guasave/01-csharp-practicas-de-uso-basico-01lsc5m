-- SQLite
select * from roles;
select * from permissions;
select * from roles_has_permissions;

pragma table_info(roles);
pragma table_info(permissions);
pragma table_info(users);
pragma table_info(roles_has_permissions);


-- Corrección de los registros de ayer
INSERT INTO roles_has_permissions (role_id, permission_id)
VALUES (1,1);

-- agregando todos los permisos a administrator
INSERT INTO roles_has_permissions
VALUES (1,2),(1,3),(1,4);

-- consulta para mostrar roles con nombres de permisos
-- Administrator has [Login,Edit,Delete,View] permissions
SELECT r.name || ' has [' || GROUP_CONCAT(p.name, ', ') || '] permissions' as c
  FROM roles r
  JOIN roles_has_permissions h
    ON r.id = h.role_id
  JOIN permissions p
    ON h.permission_id = p.id;

-- consulta para mostrar los usuarios y su nombre de rol
SELECT u.id,u.name,u.firstname || ' ' || u.lastname,r.name
  FROM users u
  JOIN roles r
    ON u.role_id = r.id
;

-- consulta para mostrar usuarios con roles y permisos
SELECT u.id as 'user_id',
       u.name as 'user_name',
       (u.firstname || ' ' || u.lastname) as 'user_fullname',
       r.name as 'role_name',
       GROUP_CONCAT(p.name, ', ') as 'permission_name'
  FROM users u
  JOIN roles r
    ON u.role_id = r.id
    JOIN roles_has_permissions h
      ON r.id = h.role_id
      JOIN permissions p
        ON h.permission_id = p.id;