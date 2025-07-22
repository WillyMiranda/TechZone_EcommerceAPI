use techzone_db;
-- subcategorías
SELECT sc.*, c.Name AS CategoryName FROM SubCategories AS sc
	INNER JOIN Categories AS c ON sc.CategoryId = c.Id
WHERE sc.IsDeleted=0;

-- productos
/* FILTROS:
ProductName,CategoryId,SubCategoryId
*/
set @ProductName = null;
set @CategoryId = UNHEX(REPLACE('550e8400-e29b-41d4-a716-446655440006', '-', ''));
set @SubCategoryId = null;

SELECT 
	p.*,c.Name AS CategoryName,sc.Name AS SubCategoryName
FROM Products AS p
	INNER JOIN Categories AS c ON p.CategoryId = c.Id
    LEFT JOIN SubCategories AS sc ON p.SubCategoryId = sc.Id
WHERE
	p.IsDeleted=0
    AND (@ProductName IS NULL OR p.Name LIKE CONCAT('%',@ProductName,'%'))
    AND (@CategoryId IS NULL OR c.Id = @CategoryId)
    AND (@SubCategoryId IS NULL OR sc.Id = @SubCategoryId);