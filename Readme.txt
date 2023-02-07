-- add Db, H_Activities_Category H_Source_Details H_CheckIns table, EFModels, H_ActivityVm
[V] add H2StyleStore mvc project
[V]Create HstyleStore db(ispan, ***), H_Activities_Category table
	H_A_Category_Id, int, PK, not null, identity
	Activity_Name, NVarchar(50), not null
	Activity_Describe, NVarchar(max), not null
	H_Value, int, not null
   Create H_Source_Details table
    Source_H_Id, int, PK, not null, identity
	Member_Id, int 
	Activity_Id, int
	Difference_H, int
	Event_Time, datetime
   Create H_CheckIns table
    CheckIn_H_Id, int
	Member_Id, Int
	Activity_Id, int
	CheckIn_Times, int
	Last_Time, datetime
[V]add EFModels, AppDbContext, connection string='AppDbConn'
[V]add ViewModels/H_Activities_CategoryVM, DTOs/H_Activities_CategoryDto class
	add �X�R��k H_Activities_CategoryDto ToDto(this H_Activities_CategoryVM source)
[V]add H_Activities_CategoryController, HcoinActivity action

-- ��@ H_ActivityService, IH_ActivityRepository, H_ActivityRepository
	display H_Activity

-- add H_Source_DetailsController, H_Source_DetailVM, H_Source_DetailService,H_Source_DetailDto
       IH_Source_DetailRepository, H_Source_DetailRepository
	   �ëإ߻PH_Activity�����p

-- �إ߻PMember�����p
   �� add EFModel/Member, Create H_Activity, Edit  H_Activity   
[V] H_Activities/Create.html, H_Activities/Create.html
[V] Index.cshtml add button to CreateActivity.cshtml
[V] add CheckIn to display from HDetail.cshtml
[V] modify ActivityController/CreateActivity{return "View"=>"RedirectToAction"}

-- add ActivityController/DeleteActivity, H_Source_DetailsController/DeleteDetail

-/- ��@���U���ʥ\�� revise(�N�s�W��H���P���U���ʦP�ɷs�W)
[V?] add H_ActivityService/HcoinRegister
[V?] add H_Source_DetailService/CreateDetail, 
                 IH_Source_DetailRepository/CreateHDetail,
				 H_Source_DetailService/CreateHDetail

-/- ��@�ʪ����B�eH��  --->�ݭn�Ҽ{�e�f���A�åB�f���e�F�n�@�Ӥ��~�i�o��H��
[V?] add H_ActivityService/HcoinOrderPrice
[V?] use H_Source_DetailService/CreateDetail, 
                 IH_Source_DetailRepository/CreateHDetail,
				 H_Source_DetailService/CreateHDetail

-- add H_Source_Detail Searchs
   [V] SelectListItem 

-- ��睊��
   [V] modify _Layout
   [V] add css file and js file

-- ��@�ͤ�eH������
   add HcoinForBirth.exe
   add EfModel connect HStyleDataBase
   add HcoinForBirth/HcoinForBirth Method

-- ��@���d���� (�e�x������)
[V?] add H_ActivityService/HcoinCheckIn
         IH_ActivityRepository/GetCheckInById
         H_activityRepository/GetCheckInById

-- �p��U�ӷ|����H���`�M
   add H_ActivityService/TotalHcoin
       IH_Source_DetailRepository/AddH_valueInMember
	   H_Source_DetailRepository/AddH_valueInMember

-- Modify H_Source_DetailsController/HDetail
          �[�JTotal���

-- �p��ToTal Hcoin�A�ǤJMember Table �� H_value���
   add H_ActivityService/TotalHcoin
       IH_ActivityRepository/AddH_valueInMember
       H_ActivityRepository/AddH_valueInMember

-- �bMember���[�J���U���ʪ��u�f
   [V] update MemberRepository/Create

-- H_Source_Detail�[�J�F Total_H_SorFar, Remark, Employee �����
   ���s�إ�EFModel�M�ק�H_Source_DetailVM, H_Source_DetailDto

-- �إ߷s�W���ʬ���

-- �N���ʱqactivityService���detailService

-- ���o���u(�ϥΪ�)�������A�۰ʰO�����ƪ�

-- ���ʬ����W�[�Ƨǥ\��

-- �إ߭קﬡ�ʬ���