// ASP.NET CoreのWebApplicationビルダーオブジェクトを作成
var builder = WebApplication.CreateBuilder(args);


// Servicesプロパティを使用して、DI（Dependency Injection）コンテナにControllersサービスを追加します。これにより、APIのコントローラーがDIに登録され、必要なときにインスタンス化されます。
builder.Services.AddControllers();
// Servicesプロパティを使用して、APIのエンドポイントのAPIエクスプローラーサービスをDIに追加します。これにより、APIエンドポイントのドキュメント生成やエクスプローラーの機能が利用可能になります。
builder.Services.AddEndpointsApiExplorer();
// Servicesプロパティを使用して、SwaggerジェネレーターサービスをDIに追加します。これにより、Swagger/OpenAPIのドキュメント生成が可能になります。
builder.Services.AddSwaggerGen();

// builder.Build()メソッドを使用して、WebApplicationオブジェクトを構築します。
var app = builder.Build();

// 現在の実行環境が開発環境かどうかを判定します。開発環境の場合は、SwaggerとSwagger UIのミドルウェアを使用します。これにより、APIのドキュメントとエクスプローラーを表示することができます。
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 認証ミドルウェアを使用して、リクエストの認証
app.UseAuthorization();

// 登録されたAPIコントローラーへのルーティングを設定
app.MapControllers();

// HTTPリクエストの処理を開始し、APIの実行
app.Run();
