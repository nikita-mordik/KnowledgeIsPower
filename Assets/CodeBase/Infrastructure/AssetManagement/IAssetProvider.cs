﻿using CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Infrastructure.AssetManagement
{
    public interface IAssetProvider : IService
    {
        void Instantiate(string path);
        GameObject Instantiate(string path, Vector3 at);
    }
}