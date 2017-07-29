alter table t_test add column status int DEFAULT 0;
alter TABLE t_test add column borrowid int DEFAULT 0; 

-- ----------------------------
-- View structure for v_archive
-- ----------------------------
DROP VIEW IF EXISTS `v_archive`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER  VIEW `v_archive` AS select a.id , a.idx , a.manager , a.number ,a.pages, a.title , a.boxid,a.operateman,a.operatetime,a.remark, a.status , (case a.status when 0 then '在库' when 1 then '借出' else '未知' end) as statusname,
 b.name as boxname , b.rfid as boxrfid , b.number as boxnumber , d.name as floorname , c.floorrfid  , CONCAT_WS(',', d.name , b.name) as position
from t_archive a left JOIN t_boxlabel b on a.boxid = b.id 
 left JOIN t_position c on b.rfid = c.boxrfid 
left JOIN t_floorlabel d on c.floorrfid = d.rfid ;

-- ----------------------------
-- View structure for v_borrow
-- ----------------------------
DROP VIEW IF EXISTS `v_borrow`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER  VIEW `v_borrow` AS select a.id , a.title,a.number, a.manager , a.idx , a.pages, a.status, (case a.status when 0 then '在库' when 1 then '借出' else '未知' end) as statusname,
b.id as boxid , b.name as boxname , b.number as boxnumber,b.rfid as boxrfid ,
CONCAT_WS(',', d.name , b.name) as position ,
d.number as floornumber , d.name as floorname,d.rfid as floorrfid,
e.createtime , e.operatorname ,
f.name as borrowername,f.idcard , f.department
from t_archive a
left join t_boxlabel b 
on a.boxid= b.id
left join t_position c
on b.rfid=c.boxrfid
left join t_floorlabel d
on c.floorrfid= d.rfid
left join t_borrow e
on a.borrowid=e.borrowid
left join t_borrower f
on e.borrowerid = f.borrowerid ;