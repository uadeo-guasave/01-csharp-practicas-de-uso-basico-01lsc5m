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