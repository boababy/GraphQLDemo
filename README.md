# GraphQLDemo

GraphQLDemoは、ASP.NET Coreを使用して構築されたシンプルなGraphQLサーバーのデモプロジェクトです。このプロジェクトでは、本の情報を管理するためのクエリとミューテーションを実装しています。

## 目次

- [特徴](#特徴)
- [前提条件](#前提条件)
- [プロジェクト構成](#プロジェクト構成)

## 特徴

- **本の一覧取得**：登録されているすべての本の情報を取得します。
- **本の詳細取得**：特定のIDを持つ本の詳細情報を取得します。
- **本の追加**：新しい本をデータに追加します。
- **本の更新**：既存の本の情報を更新します。
- **本の削除**：特定の本をデータから削除します。

## 前提条件

このプロジェクトを実行するには、以下のソフトウェアが必要です：

- .NET 8.0 SDK
- 任意のC#対応のエディタ（[Visual Studio](https://visualstudio.microsoft.com/)、[Visual Studio Code](https://code.visualstudio.com/)など）

## プロジェクト構成
```
GraphQLDemo/
├── Controllers/
├── Data/
│   └── BookRepository.cs
├── GraphQL/
│   ├── Inputs/
│   │   └── BookInputType.cs
│   ├── Mutations/
│   │   └── BookMutation.cs
│   ├── Queries/
│   │   └── BookQuery.cs
│   ├── Types/
│   │   └── BookType.cs
│   └── BookSchema.cs
├── Models/
│   └── Book.cs
├── Program.cs
└── GraphQLDemo.csproj
```
