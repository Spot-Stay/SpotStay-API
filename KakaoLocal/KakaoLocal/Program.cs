using KakaoLocal;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ILocalService, LocalService>();  //**************

// 컨트롤러 서비스 등록
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); // API 엔드포인트 탐색기
builder.Services.AddSwaggerGen();           // Swagger 생성기


var app = builder.Build();

if (app.Environment.IsDevelopment()) // 개발 환경에서만 띄우기
{
    app.UseSwagger();   // swagger.json 파일 생성
    app.UseSwaggerUI(); // 웹 브라우저에 UI 화면 표시
}

app.UseAuthorization();
// 컨트롤러 경로 매핑
app.MapControllers();

app.Run();

