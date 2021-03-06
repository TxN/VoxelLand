#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter
{
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;
    using global::ZeroFormatter.Comparers;

    public static partial class ZeroFormatterInitializer
    {
        static bool registered = false;

        [UnityEngine.RuntimeInitializeOnLoadMethod(UnityEngine.RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Register()
        {
            if(registered) return;
            registered = true;
            // Enums
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::DataStructures.ViliWonka.Tests.QType>.Register(new ZeroFormatter.DynamicObjectSegments.DataStructures.ViliWonka.Tests.QTypeFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::DataStructures.ViliWonka.Tests.QType>.Register(new ZeroFormatter.DynamicObjectSegments.DataStructures.ViliWonka.Tests.QTypeEqualityComparer());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::DataStructures.ViliWonka.Tests.QType?>.Register(new ZeroFormatter.DynamicObjectSegments.DataStructures.ViliWonka.Tests.NullableQTypeFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::DataStructures.ViliWonka.Tests.QType?>.Register(new NullableEqualityComparer<global::DataStructures.ViliWonka.Tests.QType>());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.BlockMeshType>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.BlockMeshTypeFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Voxels.BlockMeshType>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.BlockMeshTypeEqualityComparer());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.BlockMeshType?>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.NullableBlockMeshTypeFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Voxels.BlockMeshType?>.Register(new NullableEqualityComparer<global::Voxels.BlockMeshType>());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.DirIndex>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.DirIndexFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Voxels.DirIndex>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.DirIndexEqualityComparer());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.DirIndex?>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.NullableDirIndexFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Voxels.DirIndex?>.Register(new NullableEqualityComparer<global::Voxels.DirIndex>());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.BlockType>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.BlockTypeFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Voxels.BlockType>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.BlockTypeEqualityComparer());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.BlockType?>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.NullableBlockTypeFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Voxels.BlockType?>.Register(new NullableEqualityComparer<global::Voxels.BlockType>());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.BlockModelType>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.BlockModelTypeFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Voxels.BlockModelType>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.BlockModelTypeEqualityComparer());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.BlockModelType?>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.NullableBlockModelTypeFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Voxels.BlockModelType?>.Register(new NullableEqualityComparer<global::Voxels.BlockModelType>());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.BlockHarvestLevel>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.BlockHarvestLevelFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Voxels.BlockHarvestLevel>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.BlockHarvestLevelEqualityComparer());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.BlockHarvestLevel?>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.NullableBlockHarvestLevelFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Voxels.BlockHarvestLevel?>.Register(new NullableEqualityComparer<global::Voxels.BlockHarvestLevel>());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.VisibilityFlags>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.VisibilityFlagsFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Voxels.VisibilityFlags>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.VisibilityFlagsEqualityComparer());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.VisibilityFlags?>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.NullableVisibilityFlagsFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Voxels.VisibilityFlags?>.Register(new NullableEqualityComparer<global::Voxels.VisibilityFlags>());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Networking.PosUpdateOptions>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.PosUpdateOptionsFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Voxels.Networking.PosUpdateOptions>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.PosUpdateOptionsEqualityComparer());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Networking.PosUpdateOptions?>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.NullablePosUpdateOptionsFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Voxels.Networking.PosUpdateOptions?>.Register(new NullableEqualityComparer<global::Voxels.Networking.PosUpdateOptions>());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Networking.PosUpdateType>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.PosUpdateTypeFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Voxels.Networking.PosUpdateType>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.PosUpdateTypeEqualityComparer());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Networking.PosUpdateType?>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.NullablePosUpdateTypeFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Voxels.Networking.PosUpdateType?>.Register(new NullableEqualityComparer<global::Voxels.Networking.PosUpdateType>());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Networking.ServerPacketID>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.ServerPacketIDFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Voxels.Networking.ServerPacketID>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.ServerPacketIDEqualityComparer());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Networking.ServerPacketID?>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.NullableServerPacketIDFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Voxels.Networking.ServerPacketID?>.Register(new NullableEqualityComparer<global::Voxels.Networking.ServerPacketID>());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Networking.ClientPacketID>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.ClientPacketIDFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Voxels.Networking.ClientPacketID>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.ClientPacketIDEqualityComparer());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Networking.ClientPacketID?>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.NullableClientPacketIDFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Voxels.Networking.ClientPacketID?>.Register(new NullableEqualityComparer<global::Voxels.Networking.ClientPacketID>());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Networking.SState>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.SStateFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Voxels.Networking.SState>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.SStateEqualityComparer());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Networking.SState?>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.NullableSStateFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Voxels.Networking.SState?>.Register(new NullableEqualityComparer<global::Voxels.Networking.SState>());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Networking.PlayerActionType>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.PlayerActionTypeFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Voxels.Networking.PlayerActionType>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.PlayerActionTypeEqualityComparer());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Networking.PlayerActionType?>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.NullablePlayerActionTypeFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Voxels.Networking.PlayerActionType?>.Register(new NullableEqualityComparer<global::Voxels.Networking.PlayerActionType>());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Networking.ChatMessageType>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.ChatMessageTypeFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Voxels.Networking.ChatMessageType>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.ChatMessageTypeEqualityComparer());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Networking.ChatMessageType?>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.NullableChatMessageTypeFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Voxels.Networking.ChatMessageType?>.Register(new NullableEqualityComparer<global::Voxels.Networking.ChatMessageType>());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Networking.Serverside.CState>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.Serverside.CStateFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Voxels.Networking.Serverside.CState>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.Serverside.CStateEqualityComparer());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Networking.Serverside.CState?>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.Serverside.NullableCStateFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Voxels.Networking.Serverside.CState?>.Register(new NullableEqualityComparer<global::Voxels.Networking.Serverside.CState>());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Networking.Serverside.Entities.FlyingBlockContactBehaviour>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.Serverside.Entities.FlyingBlockContactBehaviourFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Voxels.Networking.Serverside.Entities.FlyingBlockContactBehaviour>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.Serverside.Entities.FlyingBlockContactBehaviourEqualityComparer());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Networking.Serverside.Entities.FlyingBlockContactBehaviour?>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.Serverside.Entities.NullableFlyingBlockContactBehaviourFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Voxels.Networking.Serverside.Entities.FlyingBlockContactBehaviour?>.Register(new NullableEqualityComparer<global::Voxels.Networking.Serverside.Entities.FlyingBlockContactBehaviour>());
            
            // Objects
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Networking.S_ChatMessage>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.S_ChatMessageFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Networking.S_EntityRPCMessage>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.S_EntityRPCMessageFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Networking.S_PutBlockMessage>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.S_PutBlockMessageFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Networking.BaseMessage>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.BaseMessageFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Networking.PlayerEntity>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.PlayerEntityFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Networking.S_PlayerUpdateMessage>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.S_PlayerUpdateMessageFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Networking.S_DespawnPlayerMessage>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.S_DespawnPlayerMessageFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Networking.S_ForceDisconnectMessage>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.S_ForceDisconnectMessageFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Networking.S_PingMessage>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.S_PingMessageFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Networking.S_WorldOptionsMessage>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.S_WorldOptionsMessageFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Networking.C_PlayerActionMessage>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.C_PlayerActionMessageFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Networking.C_PutBlockMessage>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.C_PutBlockMessageFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Networking.S_JoinSuccessMessage>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.S_JoinSuccessMessageFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Networking.S_UpdateEntityRotMessage>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.S_UpdateEntityRotMessageFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Networking.NetworkedEntity>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.NetworkedEntityFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Networking.S_SpawnEntityMessage>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.S_SpawnEntityMessageFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Networking.C_ChatMessage>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.C_ChatMessageFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Networking.S_LoadFinalizeMessage>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.S_LoadFinalizeMessageFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Networking.S_UpdateEntityPosRotMessage>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.S_UpdateEntityPosRotMessageFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Networking.C_PlayerUpdateMessage>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.C_PlayerUpdateMessageFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Networking.S_UnloadChunkMessage>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.S_UnloadChunkMessageFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Networking.S_DespawnEntityMessage>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.S_DespawnEntityMessageFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Networking.S_PosAndOrientationUpdateMessage>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.S_PosAndOrientationUpdateMessageFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Networking.C_PosAndOrientationUpdateMessage>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.C_PosAndOrientationUpdateMessageFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Networking.C_HandshakeMessage>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.C_HandshakeMessageFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Networking.S_SpawnPlayerMessage>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.S_SpawnPlayerMessageFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Networking.S_HandshakeMessage>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.S_HandshakeMessageFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Networking.S_UpdateEntityPosMessage>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.S_UpdateEntityPosMessageFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Networking.C_PongMessage>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.C_PongMessageFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Networking.S_UpdateEntityMessage>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.S_UpdateEntityMessageFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.BlockDataHolder>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.BlockDataHolderFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.BlockDataArrayHint>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.BlockDataArrayHintFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.VisibilityFlagsArrayHint>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.VisibilityFlagsArrayHintFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Int3HashsetHint>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Int3HashsetHintFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.VisibilityFlagsHolder>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.VisibilityFlagsHolderFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.ChunkData>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.ChunkDataFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Networking.Serverside.WorldOptionsDataHolder>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.Serverside.WorldOptionsDataHolderFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Networking.Serverside.MainDataHolder>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.Serverside.MainDataHolderFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Networking.Clientside.Entities.FlyingBlockClientState>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.Clientside.Entities.FlyingBlockClientStateFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Networking.Serverside.Entities.FlyingBlockServerState>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.Serverside.Entities.FlyingBlockServerStateFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            // Structs
            {
                var structFormatter = new ZeroFormatter.DynamicObjectSegments.Voxels.BlockDataFormatter<ZeroFormatter.Formatters.DefaultResolver>();
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.BlockData>.Register(structFormatter);
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.BlockData?>.Register(new global::ZeroFormatter.Formatters.NullableStructFormatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.BlockData>(structFormatter));
            }
            {
                var structFormatter = new ZeroFormatter.DynamicObjectSegments.Voxels.Byte3Formatter<ZeroFormatter.Formatters.DefaultResolver>();
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Byte3>.Register(structFormatter);
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Byte3?>.Register(new global::ZeroFormatter.Formatters.NullableStructFormatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Byte3>(structFormatter));
            }
            {
                var structFormatter = new ZeroFormatter.DynamicObjectSegments.Voxels.Int3Formatter<ZeroFormatter.Formatters.DefaultResolver>();
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Int3>.Register(structFormatter);
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Int3?>.Register(new global::ZeroFormatter.Formatters.NullableStructFormatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Int3>(structFormatter));
            }
            {
                var structFormatter = new ZeroFormatter.DynamicObjectSegments.UnityEngine.Vector3Formatter<ZeroFormatter.Formatters.DefaultResolver>();
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::UnityEngine.Vector3>.Register(structFormatter);
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::UnityEngine.Vector3?>.Register(new global::ZeroFormatter.Formatters.NullableStructFormatter<ZeroFormatter.Formatters.DefaultResolver, global::UnityEngine.Vector3>(structFormatter));
            }
            {
                var structFormatter = new ZeroFormatter.DynamicObjectSegments.UnityEngine.Vector2Formatter<ZeroFormatter.Formatters.DefaultResolver>();
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::UnityEngine.Vector2>.Register(structFormatter);
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::UnityEngine.Vector2?>.Register(new global::ZeroFormatter.Formatters.NullableStructFormatter<ZeroFormatter.Formatters.DefaultResolver, global::UnityEngine.Vector2>(structFormatter));
            }
            // Unions
            // Generics
            ZeroFormatter.Formatters.Formatter.RegisterArray<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.BlockData>();
            ZeroFormatter.Formatters.Formatter.RegisterArray<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Int3>();
            ZeroFormatter.Formatters.Formatter.RegisterArray<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.VisibilityFlags>();
            ZeroFormatter.Formatters.Formatter.RegisterCollection<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Int3, global::System.Collections.Generic.HashSet<global::Voxels.Int3>>();
        }
    }
}
#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter.DynamicObjectSegments.Voxels.Networking
{
    using global::System;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;

    public class S_ChatMessageFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Networking.S_ChatMessage>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Networking.S_ChatMessage value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (3 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, byte>(ref bytes, startOffset, offset, 0, value.CommandID);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string>(ref bytes, startOffset, offset, 1, value.SenderName);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string>(ref bytes, startOffset, offset, 2, value.MessageText);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::Voxels.Networking.ChatMessageType>(ref bytes, startOffset, offset, 3, value.Type);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 3);
            }
        }

        public override global::Voxels.Networking.S_ChatMessage Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new S_ChatMessageObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class S_ChatMessageObjectSegment<TTypeResolver> : global::Voxels.Networking.S_ChatMessage, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 1, 0, 0, 1 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, string> _SenderName;
        CacheSegment<TTypeResolver, string> _MessageText;

        // 0
        public override byte CommandID
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 1
        public override string SenderName
        {
            get
            {
                return _SenderName.Value;
            }
            set
            {
                _SenderName.Value = value;
            }
        }

        // 2
        public override string MessageText
        {
            get
            {
                return _MessageText.Value;
            }
            set
            {
                _MessageText.Value = value;
            }
        }

        // 3
        public override global::Voxels.Networking.ChatMessageType Type
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, global::Voxels.Networking.ChatMessageType>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, global::Voxels.Networking.ChatMessageType>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public S_ChatMessageObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 3, __elementSizes);

            _SenderName = new CacheSegment<TTypeResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 1, __binaryLastIndex, __tracker));
            _MessageText = new CacheSegment<TTypeResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 2, __binaryLastIndex, __tracker));
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (3 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, byte>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string>(ref targetBytes, startOffset, offset, 1, ref _SenderName);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string>(ref targetBytes, startOffset, offset, 2, ref _MessageText);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, global::Voxels.Networking.ChatMessageType>(ref targetBytes, startOffset, offset, 3, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 3);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class S_EntityRPCMessageFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Networking.S_EntityRPCMessage>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Networking.S_EntityRPCMessage value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (2 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, byte>(ref bytes, startOffset, offset, 0, value.CommandID);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, uint>(ref bytes, startOffset, offset, 1, value.UID);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, uint>(ref bytes, startOffset, offset, 2, value.MethodName);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 2);
            }
        }

        public override global::Voxels.Networking.S_EntityRPCMessage Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new S_EntityRPCMessageObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class S_EntityRPCMessageObjectSegment<TTypeResolver> : global::Voxels.Networking.S_EntityRPCMessage, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 1, 4, 4 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;


        // 0
        public override byte CommandID
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 1
        public override uint UID
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, uint>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, uint>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 2
        public override uint MethodName
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, uint>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, uint>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public S_EntityRPCMessageObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 2, __elementSizes);

        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (2 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, byte>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, uint>(ref targetBytes, startOffset, offset, 1, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, uint>(ref targetBytes, startOffset, offset, 2, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 2);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class S_PutBlockMessageFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Networking.S_PutBlockMessage>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Networking.S_PutBlockMessage value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (5 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, byte>(ref bytes, startOffset, offset, 0, value.CommandID);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::Voxels.BlockData>(ref bytes, startOffset, offset, 1, value.Block);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 2, value.X);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 3, value.Y);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 4, value.Z);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, bool>(ref bytes, startOffset, offset, 5, value.Put);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 5);
            }
        }

        public override global::Voxels.Networking.S_PutBlockMessage Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new S_PutBlockMessageObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class S_PutBlockMessageObjectSegment<TTypeResolver> : global::Voxels.Networking.S_PutBlockMessage, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 1, 0, 4, 4, 4, 1 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, global::Voxels.BlockData> _Block;

        // 0
        public override byte CommandID
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 1
        public override global::Voxels.BlockData Block
        {
            get
            {
                return _Block.Value;
            }
            set
            {
                _Block.Value = value;
            }
        }

        // 2
        public override int X
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 3
        public override int Y
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 4
        public override int Z
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 4, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 4, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 5
        public override bool Put
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, bool>(__originalBytes, 5, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, bool>(__originalBytes, 5, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public S_PutBlockMessageObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 5, __elementSizes);

            _Block = new CacheSegment<TTypeResolver, global::Voxels.BlockData>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 1, __binaryLastIndex, __tracker));
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (5 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, byte>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::Voxels.BlockData>(ref targetBytes, startOffset, offset, 1, ref _Block);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 2, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 3, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 4, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, bool>(ref targetBytes, startOffset, offset, 5, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 5);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class BaseMessageFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Networking.BaseMessage>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Networking.BaseMessage value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (0 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, byte>(ref bytes, startOffset, offset, 0, value.CommandID);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 0);
            }
        }

        public override global::Voxels.Networking.BaseMessage Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new BaseMessageObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class BaseMessageObjectSegment<TTypeResolver> : global::Voxels.Networking.BaseMessage, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 1 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;


        // 0
        public override byte CommandID
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public BaseMessageObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 0, __elementSizes);

        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (0 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, byte>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 0);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class PlayerEntityFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Networking.PlayerEntity>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Networking.PlayerEntity value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (3 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, ushort>(ref bytes, startOffset, offset, 0, value.ConId);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string>(ref bytes, startOffset, offset, 1, value.PlayerName);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::UnityEngine.Vector3>(ref bytes, startOffset, offset, 2, value.Position);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::UnityEngine.Vector2>(ref bytes, startOffset, offset, 3, value.LookDir);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 3);
            }
        }

        public override global::Voxels.Networking.PlayerEntity Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new PlayerEntityObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class PlayerEntityObjectSegment<TTypeResolver> : global::Voxels.Networking.PlayerEntity, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 2, 0, 0, 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, string> _PlayerName;
        CacheSegment<TTypeResolver, global::UnityEngine.Vector3> _Position;
        CacheSegment<TTypeResolver, global::UnityEngine.Vector2> _LookDir;

        // 0
        public override ushort ConId
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, ushort>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, ushort>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 1
        public override string PlayerName
        {
            get
            {
                return _PlayerName.Value;
            }
            set
            {
                _PlayerName.Value = value;
            }
        }

        // 2
        public override global::UnityEngine.Vector3 Position
        {
            get
            {
                return _Position.Value;
            }
            set
            {
                _Position.Value = value;
            }
        }

        // 3
        public override global::UnityEngine.Vector2 LookDir
        {
            get
            {
                return _LookDir.Value;
            }
            set
            {
                _LookDir.Value = value;
            }
        }


        public PlayerEntityObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 3, __elementSizes);

            _PlayerName = new CacheSegment<TTypeResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 1, __binaryLastIndex, __tracker));
            _Position = new CacheSegment<TTypeResolver, global::UnityEngine.Vector3>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 2, __binaryLastIndex, __tracker));
            _LookDir = new CacheSegment<TTypeResolver, global::UnityEngine.Vector2>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 3, __binaryLastIndex, __tracker));
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (3 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, ushort>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string>(ref targetBytes, startOffset, offset, 1, ref _PlayerName);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::UnityEngine.Vector3>(ref targetBytes, startOffset, offset, 2, ref _Position);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::UnityEngine.Vector2>(ref targetBytes, startOffset, offset, 3, ref _LookDir);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 3);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class S_PlayerUpdateMessageFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Networking.S_PlayerUpdateMessage>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Networking.S_PlayerUpdateMessage value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (2 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, byte>(ref bytes, startOffset, offset, 0, value.CommandID);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::Voxels.Networking.PlayerEntity>(ref bytes, startOffset, offset, 1, value.Player);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, bool>(ref bytes, startOffset, offset, 2, value.Teleport);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 2);
            }
        }

        public override global::Voxels.Networking.S_PlayerUpdateMessage Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new S_PlayerUpdateMessageObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class S_PlayerUpdateMessageObjectSegment<TTypeResolver> : global::Voxels.Networking.S_PlayerUpdateMessage, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 1, 0, 1 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        global::Voxels.Networking.PlayerEntity _Player;

        // 0
        public override byte CommandID
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 1
        public override global::Voxels.Networking.PlayerEntity Player
        {
            get
            {
                return _Player;
            }
            set
            {
                __tracker.Dirty();
                _Player = value;
            }
        }

        // 2
        public override bool Teleport
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, bool>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, bool>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public S_PlayerUpdateMessageObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 2, __elementSizes);

            _Player = ObjectSegmentHelper.DeserializeSegment<TTypeResolver, global::Voxels.Networking.PlayerEntity>(originalBytes, 1, __binaryLastIndex, __tracker);
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (2 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, byte>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeSegment<TTypeResolver, global::Voxels.Networking.PlayerEntity>(ref targetBytes, startOffset, offset, 1, _Player);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, bool>(ref targetBytes, startOffset, offset, 2, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 2);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class S_DespawnPlayerMessageFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Networking.S_DespawnPlayerMessage>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Networking.S_DespawnPlayerMessage value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (1 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, byte>(ref bytes, startOffset, offset, 0, value.CommandID);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::Voxels.Networking.PlayerEntity>(ref bytes, startOffset, offset, 1, value.PlayerToDespawn);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 1);
            }
        }

        public override global::Voxels.Networking.S_DespawnPlayerMessage Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new S_DespawnPlayerMessageObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class S_DespawnPlayerMessageObjectSegment<TTypeResolver> : global::Voxels.Networking.S_DespawnPlayerMessage, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 1, 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        global::Voxels.Networking.PlayerEntity _PlayerToDespawn;

        // 0
        public override byte CommandID
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 1
        public override global::Voxels.Networking.PlayerEntity PlayerToDespawn
        {
            get
            {
                return _PlayerToDespawn;
            }
            set
            {
                __tracker.Dirty();
                _PlayerToDespawn = value;
            }
        }


        public S_DespawnPlayerMessageObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 1, __elementSizes);

            _PlayerToDespawn = ObjectSegmentHelper.DeserializeSegment<TTypeResolver, global::Voxels.Networking.PlayerEntity>(originalBytes, 1, __binaryLastIndex, __tracker);
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (1 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, byte>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeSegment<TTypeResolver, global::Voxels.Networking.PlayerEntity>(ref targetBytes, startOffset, offset, 1, _PlayerToDespawn);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 1);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class S_ForceDisconnectMessageFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Networking.S_ForceDisconnectMessage>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Networking.S_ForceDisconnectMessage value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (1 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, byte>(ref bytes, startOffset, offset, 0, value.CommandID);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string>(ref bytes, startOffset, offset, 1, value.Reason);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 1);
            }
        }

        public override global::Voxels.Networking.S_ForceDisconnectMessage Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new S_ForceDisconnectMessageObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class S_ForceDisconnectMessageObjectSegment<TTypeResolver> : global::Voxels.Networking.S_ForceDisconnectMessage, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 1, 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, string> _Reason;

        // 0
        public override byte CommandID
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 1
        public override string Reason
        {
            get
            {
                return _Reason.Value;
            }
            set
            {
                _Reason.Value = value;
            }
        }


        public S_ForceDisconnectMessageObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 1, __elementSizes);

            _Reason = new CacheSegment<TTypeResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 1, __binaryLastIndex, __tracker));
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (1 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, byte>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string>(ref targetBytes, startOffset, offset, 1, ref _Reason);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 1);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class S_PingMessageFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Networking.S_PingMessage>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Networking.S_PingMessage value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (0 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, byte>(ref bytes, startOffset, offset, 0, value.CommandID);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 0);
            }
        }

        public override global::Voxels.Networking.S_PingMessage Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new S_PingMessageObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class S_PingMessageObjectSegment<TTypeResolver> : global::Voxels.Networking.S_PingMessage, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 1 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;


        // 0
        public override byte CommandID
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public S_PingMessageObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 0, __elementSizes);

        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (0 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, byte>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 0);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class S_WorldOptionsMessageFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Networking.S_WorldOptionsMessage>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Networking.S_WorldOptionsMessage value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (4 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, byte>(ref bytes, startOffset, offset, 0, value.CommandID);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 1, value.Seed);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, float>(ref bytes, startOffset, offset, 2, value.Time);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, float>(ref bytes, startOffset, offset, 3, value.TimeMultiplier);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, float>(ref bytes, startOffset, offset, 4, value.DayLength);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 4);
            }
        }

        public override global::Voxels.Networking.S_WorldOptionsMessage Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new S_WorldOptionsMessageObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class S_WorldOptionsMessageObjectSegment<TTypeResolver> : global::Voxels.Networking.S_WorldOptionsMessage, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 1, 4, 4, 4, 4 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;


        // 0
        public override byte CommandID
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 1
        public override int Seed
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 2
        public override float Time
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, float>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, float>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 3
        public override float TimeMultiplier
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, float>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, float>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 4
        public override float DayLength
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, float>(__originalBytes, 4, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, float>(__originalBytes, 4, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public S_WorldOptionsMessageObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 4, __elementSizes);

        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (4 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, byte>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 1, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, float>(ref targetBytes, startOffset, offset, 2, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, float>(ref targetBytes, startOffset, offset, 3, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, float>(ref targetBytes, startOffset, offset, 4, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 4);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class C_PlayerActionMessageFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Networking.C_PlayerActionMessage>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Networking.C_PlayerActionMessage value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (5 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, byte>(ref bytes, startOffset, offset, 0, value.CommandID);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::Voxels.Networking.PlayerActionType>(ref bytes, startOffset, offset, 1, value.Action);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string>(ref bytes, startOffset, offset, 2, value.PayloadString);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 3, value.PayloadInt);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, float>(ref bytes, startOffset, offset, 4, value.LookYaw);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, float>(ref bytes, startOffset, offset, 5, value.LookPitch);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 5);
            }
        }

        public override global::Voxels.Networking.C_PlayerActionMessage Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new C_PlayerActionMessageObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class C_PlayerActionMessageObjectSegment<TTypeResolver> : global::Voxels.Networking.C_PlayerActionMessage, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 1, 1, 0, 4, 4, 4 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, string> _PayloadString;

        // 0
        public override byte CommandID
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 1
        public override global::Voxels.Networking.PlayerActionType Action
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, global::Voxels.Networking.PlayerActionType>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, global::Voxels.Networking.PlayerActionType>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 2
        public override string PayloadString
        {
            get
            {
                return _PayloadString.Value;
            }
            set
            {
                _PayloadString.Value = value;
            }
        }

        // 3
        public override int PayloadInt
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 4
        public override float LookYaw
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, float>(__originalBytes, 4, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, float>(__originalBytes, 4, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 5
        public override float LookPitch
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, float>(__originalBytes, 5, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, float>(__originalBytes, 5, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public C_PlayerActionMessageObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 5, __elementSizes);

            _PayloadString = new CacheSegment<TTypeResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 2, __binaryLastIndex, __tracker));
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (5 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, byte>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, global::Voxels.Networking.PlayerActionType>(ref targetBytes, startOffset, offset, 1, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string>(ref targetBytes, startOffset, offset, 2, ref _PayloadString);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 3, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, float>(ref targetBytes, startOffset, offset, 4, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, float>(ref targetBytes, startOffset, offset, 5, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 5);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class C_PutBlockMessageFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Networking.C_PutBlockMessage>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Networking.C_PutBlockMessage value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (5 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, byte>(ref bytes, startOffset, offset, 0, value.CommandID);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::Voxels.BlockData>(ref bytes, startOffset, offset, 1, value.Block);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 2, value.X);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 3, value.Y);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 4, value.Z);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, bool>(ref bytes, startOffset, offset, 5, value.Put);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 5);
            }
        }

        public override global::Voxels.Networking.C_PutBlockMessage Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new C_PutBlockMessageObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class C_PutBlockMessageObjectSegment<TTypeResolver> : global::Voxels.Networking.C_PutBlockMessage, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 1, 0, 4, 4, 4, 1 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, global::Voxels.BlockData> _Block;

        // 0
        public override byte CommandID
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 1
        public override global::Voxels.BlockData Block
        {
            get
            {
                return _Block.Value;
            }
            set
            {
                _Block.Value = value;
            }
        }

        // 2
        public override int X
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 3
        public override int Y
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 4
        public override int Z
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 4, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 4, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 5
        public override bool Put
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, bool>(__originalBytes, 5, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, bool>(__originalBytes, 5, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public C_PutBlockMessageObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 5, __elementSizes);

            _Block = new CacheSegment<TTypeResolver, global::Voxels.BlockData>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 1, __binaryLastIndex, __tracker));
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (5 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, byte>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::Voxels.BlockData>(ref targetBytes, startOffset, offset, 1, ref _Block);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 2, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 3, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 4, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, bool>(ref targetBytes, startOffset, offset, 5, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 5);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class S_JoinSuccessMessageFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Networking.S_JoinSuccessMessage>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Networking.S_JoinSuccessMessage value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (0 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, byte>(ref bytes, startOffset, offset, 0, value.CommandID);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 0);
            }
        }

        public override global::Voxels.Networking.S_JoinSuccessMessage Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new S_JoinSuccessMessageObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class S_JoinSuccessMessageObjectSegment<TTypeResolver> : global::Voxels.Networking.S_JoinSuccessMessage, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 1 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;


        // 0
        public override byte CommandID
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public S_JoinSuccessMessageObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 0, __elementSizes);

        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (0 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, byte>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 0);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class S_UpdateEntityRotMessageFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Networking.S_UpdateEntityRotMessage>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Networking.S_UpdateEntityRotMessage value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (2 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, byte>(ref bytes, startOffset, offset, 0, value.CommandID);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::Voxels.Byte3>(ref bytes, startOffset, offset, 1, value.Rotation);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, uint>(ref bytes, startOffset, offset, 2, value.UID);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 2);
            }
        }

        public override global::Voxels.Networking.S_UpdateEntityRotMessage Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new S_UpdateEntityRotMessageObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class S_UpdateEntityRotMessageObjectSegment<TTypeResolver> : global::Voxels.Networking.S_UpdateEntityRotMessage, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 1, 0, 4 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, global::Voxels.Byte3> _Rotation;

        // 0
        public override byte CommandID
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 1
        public override global::Voxels.Byte3 Rotation
        {
            get
            {
                return _Rotation.Value;
            }
            set
            {
                _Rotation.Value = value;
            }
        }

        // 2
        public override uint UID
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, uint>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, uint>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public S_UpdateEntityRotMessageObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 2, __elementSizes);

            _Rotation = new CacheSegment<TTypeResolver, global::Voxels.Byte3>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 1, __binaryLastIndex, __tracker));
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (2 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, byte>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::Voxels.Byte3>(ref targetBytes, startOffset, offset, 1, ref _Rotation);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, uint>(ref targetBytes, startOffset, offset, 2, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 2);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class NetworkedEntityFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Networking.NetworkedEntity>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Networking.NetworkedEntity value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (0 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 0, value.UID);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 0);
            }
        }

        public override global::Voxels.Networking.NetworkedEntity Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new NetworkedEntityObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class NetworkedEntityObjectSegment<TTypeResolver> : global::Voxels.Networking.NetworkedEntity, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 4 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;


        // 0
        public override int UID
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public NetworkedEntityObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 0, __elementSizes);

        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (0 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 0);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class S_SpawnEntityMessageFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Networking.S_SpawnEntityMessage>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Networking.S_SpawnEntityMessage value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (5 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, byte>(ref bytes, startOffset, offset, 0, value.CommandID);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, uint>(ref bytes, startOffset, offset, 1, value.UID);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string>(ref bytes, startOffset, offset, 2, value.TypeName);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::UnityEngine.Vector3>(ref bytes, startOffset, offset, 3, value.Position);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::Voxels.Byte3>(ref bytes, startOffset, offset, 4, value.Rotation);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, byte[]>(ref bytes, startOffset, offset, 5, value.State);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 5);
            }
        }

        public override global::Voxels.Networking.S_SpawnEntityMessage Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new S_SpawnEntityMessageObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class S_SpawnEntityMessageObjectSegment<TTypeResolver> : global::Voxels.Networking.S_SpawnEntityMessage, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 1, 4, 0, 0, 0, 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, string> _TypeName;
        CacheSegment<TTypeResolver, global::UnityEngine.Vector3> _Position;
        CacheSegment<TTypeResolver, global::Voxels.Byte3> _Rotation;
        CacheSegment<TTypeResolver, byte[]> _State;

        // 0
        public override byte CommandID
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 1
        public override uint UID
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, uint>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, uint>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 2
        public override string TypeName
        {
            get
            {
                return _TypeName.Value;
            }
            set
            {
                _TypeName.Value = value;
            }
        }

        // 3
        public override global::UnityEngine.Vector3 Position
        {
            get
            {
                return _Position.Value;
            }
            set
            {
                _Position.Value = value;
            }
        }

        // 4
        public override global::Voxels.Byte3 Rotation
        {
            get
            {
                return _Rotation.Value;
            }
            set
            {
                _Rotation.Value = value;
            }
        }

        // 5
        public override byte[] State
        {
            get
            {
                return _State.Value;
            }
            set
            {
                _State.Value = value;
            }
        }


        public S_SpawnEntityMessageObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 5, __elementSizes);

            _TypeName = new CacheSegment<TTypeResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 2, __binaryLastIndex, __tracker));
            _Position = new CacheSegment<TTypeResolver, global::UnityEngine.Vector3>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 3, __binaryLastIndex, __tracker));
            _Rotation = new CacheSegment<TTypeResolver, global::Voxels.Byte3>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 4, __binaryLastIndex, __tracker));
            _State = new CacheSegment<TTypeResolver, byte[]>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 5, __binaryLastIndex, __tracker));
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (5 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, byte>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, uint>(ref targetBytes, startOffset, offset, 1, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string>(ref targetBytes, startOffset, offset, 2, ref _TypeName);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::UnityEngine.Vector3>(ref targetBytes, startOffset, offset, 3, ref _Position);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::Voxels.Byte3>(ref targetBytes, startOffset, offset, 4, ref _Rotation);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, byte[]>(ref targetBytes, startOffset, offset, 5, ref _State);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 5);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class C_ChatMessageFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Networking.C_ChatMessage>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Networking.C_ChatMessage value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (1 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, byte>(ref bytes, startOffset, offset, 0, value.CommandID);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string>(ref bytes, startOffset, offset, 1, value.MessageText);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 1);
            }
        }

        public override global::Voxels.Networking.C_ChatMessage Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new C_ChatMessageObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class C_ChatMessageObjectSegment<TTypeResolver> : global::Voxels.Networking.C_ChatMessage, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 1, 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, string> _MessageText;

        // 0
        public override byte CommandID
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 1
        public override string MessageText
        {
            get
            {
                return _MessageText.Value;
            }
            set
            {
                _MessageText.Value = value;
            }
        }


        public C_ChatMessageObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 1, __elementSizes);

            _MessageText = new CacheSegment<TTypeResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 1, __binaryLastIndex, __tracker));
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (1 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, byte>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string>(ref targetBytes, startOffset, offset, 1, ref _MessageText);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 1);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class S_LoadFinalizeMessageFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Networking.S_LoadFinalizeMessage>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Networking.S_LoadFinalizeMessage value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (0 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, byte>(ref bytes, startOffset, offset, 0, value.CommandID);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 0);
            }
        }

        public override global::Voxels.Networking.S_LoadFinalizeMessage Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new S_LoadFinalizeMessageObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class S_LoadFinalizeMessageObjectSegment<TTypeResolver> : global::Voxels.Networking.S_LoadFinalizeMessage, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 1 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;


        // 0
        public override byte CommandID
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public S_LoadFinalizeMessageObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 0, __elementSizes);

        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (0 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, byte>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 0);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class S_UpdateEntityPosRotMessageFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Networking.S_UpdateEntityPosRotMessage>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Networking.S_UpdateEntityPosRotMessage value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (3 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, byte>(ref bytes, startOffset, offset, 0, value.CommandID);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::UnityEngine.Vector3>(ref bytes, startOffset, offset, 1, value.Position);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::Voxels.Byte3>(ref bytes, startOffset, offset, 2, value.Rotation);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, uint>(ref bytes, startOffset, offset, 3, value.UID);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 3);
            }
        }

        public override global::Voxels.Networking.S_UpdateEntityPosRotMessage Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new S_UpdateEntityPosRotMessageObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class S_UpdateEntityPosRotMessageObjectSegment<TTypeResolver> : global::Voxels.Networking.S_UpdateEntityPosRotMessage, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 1, 0, 0, 4 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, global::UnityEngine.Vector3> _Position;
        CacheSegment<TTypeResolver, global::Voxels.Byte3> _Rotation;

        // 0
        public override byte CommandID
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 1
        public override global::UnityEngine.Vector3 Position
        {
            get
            {
                return _Position.Value;
            }
            set
            {
                _Position.Value = value;
            }
        }

        // 2
        public override global::Voxels.Byte3 Rotation
        {
            get
            {
                return _Rotation.Value;
            }
            set
            {
                _Rotation.Value = value;
            }
        }

        // 3
        public override uint UID
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, uint>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, uint>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public S_UpdateEntityPosRotMessageObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 3, __elementSizes);

            _Position = new CacheSegment<TTypeResolver, global::UnityEngine.Vector3>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 1, __binaryLastIndex, __tracker));
            _Rotation = new CacheSegment<TTypeResolver, global::Voxels.Byte3>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 2, __binaryLastIndex, __tracker));
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (3 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, byte>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::UnityEngine.Vector3>(ref targetBytes, startOffset, offset, 1, ref _Position);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::Voxels.Byte3>(ref targetBytes, startOffset, offset, 2, ref _Rotation);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, uint>(ref targetBytes, startOffset, offset, 3, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 3);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class C_PlayerUpdateMessageFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Networking.C_PlayerUpdateMessage>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Networking.C_PlayerUpdateMessage value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (1 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, byte>(ref bytes, startOffset, offset, 0, value.CommandID);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::Voxels.Networking.PlayerEntity>(ref bytes, startOffset, offset, 1, value.PlayerInfo);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 1);
            }
        }

        public override global::Voxels.Networking.C_PlayerUpdateMessage Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new C_PlayerUpdateMessageObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class C_PlayerUpdateMessageObjectSegment<TTypeResolver> : global::Voxels.Networking.C_PlayerUpdateMessage, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 1, 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        global::Voxels.Networking.PlayerEntity _PlayerInfo;

        // 0
        public override byte CommandID
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 1
        public override global::Voxels.Networking.PlayerEntity PlayerInfo
        {
            get
            {
                return _PlayerInfo;
            }
            set
            {
                __tracker.Dirty();
                _PlayerInfo = value;
            }
        }


        public C_PlayerUpdateMessageObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 1, __elementSizes);

            _PlayerInfo = ObjectSegmentHelper.DeserializeSegment<TTypeResolver, global::Voxels.Networking.PlayerEntity>(originalBytes, 1, __binaryLastIndex, __tracker);
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (1 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, byte>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeSegment<TTypeResolver, global::Voxels.Networking.PlayerEntity>(ref targetBytes, startOffset, offset, 1, _PlayerInfo);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 1);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class S_UnloadChunkMessageFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Networking.S_UnloadChunkMessage>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Networking.S_UnloadChunkMessage value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (3 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, byte>(ref bytes, startOffset, offset, 0, value.CommandID);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 1, value.X);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 2, value.Y);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 3, value.Z);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 3);
            }
        }

        public override global::Voxels.Networking.S_UnloadChunkMessage Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new S_UnloadChunkMessageObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class S_UnloadChunkMessageObjectSegment<TTypeResolver> : global::Voxels.Networking.S_UnloadChunkMessage, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 1, 4, 4, 4 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;


        // 0
        public override byte CommandID
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 1
        public override int X
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 2
        public override int Y
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 3
        public override int Z
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public S_UnloadChunkMessageObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 3, __elementSizes);

        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (3 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, byte>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 1, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 2, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 3, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 3);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class S_DespawnEntityMessageFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Networking.S_DespawnEntityMessage>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Networking.S_DespawnEntityMessage value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (1 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, byte>(ref bytes, startOffset, offset, 0, value.CommandID);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, uint>(ref bytes, startOffset, offset, 1, value.UID);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 1);
            }
        }

        public override global::Voxels.Networking.S_DespawnEntityMessage Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new S_DespawnEntityMessageObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class S_DespawnEntityMessageObjectSegment<TTypeResolver> : global::Voxels.Networking.S_DespawnEntityMessage, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 1, 4 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;


        // 0
        public override byte CommandID
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 1
        public override uint UID
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, uint>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, uint>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public S_DespawnEntityMessageObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 1, __elementSizes);

        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (1 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, byte>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, uint>(ref targetBytes, startOffset, offset, 1, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 1);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class S_PosAndOrientationUpdateMessageFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Networking.S_PosAndOrientationUpdateMessage>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Networking.S_PosAndOrientationUpdateMessage value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (4 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, byte>(ref bytes, startOffset, offset, 0, value.CommandID);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, ushort>(ref bytes, startOffset, offset, 1, value.ConId);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::UnityEngine.Vector3>(ref bytes, startOffset, offset, 2, value.Position);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, byte>(ref bytes, startOffset, offset, 3, value.LookPitch);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, byte>(ref bytes, startOffset, offset, 4, value.Yaw);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 4);
            }
        }

        public override global::Voxels.Networking.S_PosAndOrientationUpdateMessage Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new S_PosAndOrientationUpdateMessageObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class S_PosAndOrientationUpdateMessageObjectSegment<TTypeResolver> : global::Voxels.Networking.S_PosAndOrientationUpdateMessage, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 1, 2, 0, 1, 1 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, global::UnityEngine.Vector3> _Position;

        // 0
        public override byte CommandID
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 1
        public override ushort ConId
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, ushort>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, ushort>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 2
        public override global::UnityEngine.Vector3 Position
        {
            get
            {
                return _Position.Value;
            }
            set
            {
                _Position.Value = value;
            }
        }

        // 3
        public override byte LookPitch
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, byte>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, byte>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 4
        public override byte Yaw
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, byte>(__originalBytes, 4, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, byte>(__originalBytes, 4, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public S_PosAndOrientationUpdateMessageObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 4, __elementSizes);

            _Position = new CacheSegment<TTypeResolver, global::UnityEngine.Vector3>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 2, __binaryLastIndex, __tracker));
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (4 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, byte>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, ushort>(ref targetBytes, startOffset, offset, 1, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::UnityEngine.Vector3>(ref targetBytes, startOffset, offset, 2, ref _Position);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, byte>(ref targetBytes, startOffset, offset, 3, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, byte>(ref targetBytes, startOffset, offset, 4, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 4);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class C_PosAndOrientationUpdateMessageFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Networking.C_PosAndOrientationUpdateMessage>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Networking.C_PosAndOrientationUpdateMessage value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (3 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, byte>(ref bytes, startOffset, offset, 0, value.CommandID);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::UnityEngine.Vector3>(ref bytes, startOffset, offset, 1, value.Position);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, byte>(ref bytes, startOffset, offset, 2, value.LookPitch);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, byte>(ref bytes, startOffset, offset, 3, value.Yaw);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 3);
            }
        }

        public override global::Voxels.Networking.C_PosAndOrientationUpdateMessage Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new C_PosAndOrientationUpdateMessageObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class C_PosAndOrientationUpdateMessageObjectSegment<TTypeResolver> : global::Voxels.Networking.C_PosAndOrientationUpdateMessage, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 1, 0, 1, 1 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, global::UnityEngine.Vector3> _Position;

        // 0
        public override byte CommandID
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 1
        public override global::UnityEngine.Vector3 Position
        {
            get
            {
                return _Position.Value;
            }
            set
            {
                _Position.Value = value;
            }
        }

        // 2
        public override byte LookPitch
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, byte>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, byte>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 3
        public override byte Yaw
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, byte>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, byte>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public C_PosAndOrientationUpdateMessageObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 3, __elementSizes);

            _Position = new CacheSegment<TTypeResolver, global::UnityEngine.Vector3>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 1, __binaryLastIndex, __tracker));
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (3 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, byte>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::UnityEngine.Vector3>(ref targetBytes, startOffset, offset, 1, ref _Position);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, byte>(ref targetBytes, startOffset, offset, 2, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, byte>(ref targetBytes, startOffset, offset, 3, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 3);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class C_HandshakeMessageFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Networking.C_HandshakeMessage>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Networking.C_HandshakeMessage value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (3 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, byte>(ref bytes, startOffset, offset, 0, value.CommandID);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string>(ref bytes, startOffset, offset, 1, value.ClientName);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string>(ref bytes, startOffset, offset, 2, value.Password);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 3, value.ProtocolVersion);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 3);
            }
        }

        public override global::Voxels.Networking.C_HandshakeMessage Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new C_HandshakeMessageObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class C_HandshakeMessageObjectSegment<TTypeResolver> : global::Voxels.Networking.C_HandshakeMessage, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 1, 0, 0, 4 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, string> _ClientName;
        CacheSegment<TTypeResolver, string> _Password;

        // 0
        public override byte CommandID
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 1
        public override string ClientName
        {
            get
            {
                return _ClientName.Value;
            }
            set
            {
                _ClientName.Value = value;
            }
        }

        // 2
        public override string Password
        {
            get
            {
                return _Password.Value;
            }
            set
            {
                _Password.Value = value;
            }
        }

        // 3
        public override int ProtocolVersion
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public C_HandshakeMessageObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 3, __elementSizes);

            _ClientName = new CacheSegment<TTypeResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 1, __binaryLastIndex, __tracker));
            _Password = new CacheSegment<TTypeResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 2, __binaryLastIndex, __tracker));
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (3 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, byte>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string>(ref targetBytes, startOffset, offset, 1, ref _ClientName);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string>(ref targetBytes, startOffset, offset, 2, ref _Password);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 3, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 3);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class S_SpawnPlayerMessageFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Networking.S_SpawnPlayerMessage>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Networking.S_SpawnPlayerMessage value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (1 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, byte>(ref bytes, startOffset, offset, 0, value.CommandID);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::Voxels.Networking.PlayerEntity>(ref bytes, startOffset, offset, 1, value.PlayerToSpawn);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 1);
            }
        }

        public override global::Voxels.Networking.S_SpawnPlayerMessage Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new S_SpawnPlayerMessageObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class S_SpawnPlayerMessageObjectSegment<TTypeResolver> : global::Voxels.Networking.S_SpawnPlayerMessage, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 1, 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        global::Voxels.Networking.PlayerEntity _PlayerToSpawn;

        // 0
        public override byte CommandID
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 1
        public override global::Voxels.Networking.PlayerEntity PlayerToSpawn
        {
            get
            {
                return _PlayerToSpawn;
            }
            set
            {
                __tracker.Dirty();
                _PlayerToSpawn = value;
            }
        }


        public S_SpawnPlayerMessageObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 1, __elementSizes);

            _PlayerToSpawn = ObjectSegmentHelper.DeserializeSegment<TTypeResolver, global::Voxels.Networking.PlayerEntity>(originalBytes, 1, __binaryLastIndex, __tracker);
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (1 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, byte>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeSegment<TTypeResolver, global::Voxels.Networking.PlayerEntity>(ref targetBytes, startOffset, offset, 1, _PlayerToSpawn);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 1);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class S_HandshakeMessageFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Networking.S_HandshakeMessage>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Networking.S_HandshakeMessage value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (3 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, byte>(ref bytes, startOffset, offset, 0, value.CommandID);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string>(ref bytes, startOffset, offset, 1, value.ServerName);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string>(ref bytes, startOffset, offset, 2, value.MOTD);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 3, value.ProtocolVersion);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 3);
            }
        }

        public override global::Voxels.Networking.S_HandshakeMessage Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new S_HandshakeMessageObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class S_HandshakeMessageObjectSegment<TTypeResolver> : global::Voxels.Networking.S_HandshakeMessage, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 1, 0, 0, 4 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, string> _ServerName;
        CacheSegment<TTypeResolver, string> _MOTD;

        // 0
        public override byte CommandID
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 1
        public override string ServerName
        {
            get
            {
                return _ServerName.Value;
            }
            set
            {
                _ServerName.Value = value;
            }
        }

        // 2
        public override string MOTD
        {
            get
            {
                return _MOTD.Value;
            }
            set
            {
                _MOTD.Value = value;
            }
        }

        // 3
        public override int ProtocolVersion
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public S_HandshakeMessageObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 3, __elementSizes);

            _ServerName = new CacheSegment<TTypeResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 1, __binaryLastIndex, __tracker));
            _MOTD = new CacheSegment<TTypeResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 2, __binaryLastIndex, __tracker));
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (3 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, byte>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string>(ref targetBytes, startOffset, offset, 1, ref _ServerName);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string>(ref targetBytes, startOffset, offset, 2, ref _MOTD);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 3, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 3);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class S_UpdateEntityPosMessageFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Networking.S_UpdateEntityPosMessage>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Networking.S_UpdateEntityPosMessage value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (2 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, byte>(ref bytes, startOffset, offset, 0, value.CommandID);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::UnityEngine.Vector3>(ref bytes, startOffset, offset, 1, value.Position);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, uint>(ref bytes, startOffset, offset, 2, value.UID);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 2);
            }
        }

        public override global::Voxels.Networking.S_UpdateEntityPosMessage Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new S_UpdateEntityPosMessageObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class S_UpdateEntityPosMessageObjectSegment<TTypeResolver> : global::Voxels.Networking.S_UpdateEntityPosMessage, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 1, 0, 4 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, global::UnityEngine.Vector3> _Position;

        // 0
        public override byte CommandID
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 1
        public override global::UnityEngine.Vector3 Position
        {
            get
            {
                return _Position.Value;
            }
            set
            {
                _Position.Value = value;
            }
        }

        // 2
        public override uint UID
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, uint>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, uint>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public S_UpdateEntityPosMessageObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 2, __elementSizes);

            _Position = new CacheSegment<TTypeResolver, global::UnityEngine.Vector3>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 1, __binaryLastIndex, __tracker));
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (2 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, byte>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::UnityEngine.Vector3>(ref targetBytes, startOffset, offset, 1, ref _Position);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, uint>(ref targetBytes, startOffset, offset, 2, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 2);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class C_PongMessageFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Networking.C_PongMessage>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Networking.C_PongMessage value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (0 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, byte>(ref bytes, startOffset, offset, 0, value.CommandID);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 0);
            }
        }

        public override global::Voxels.Networking.C_PongMessage Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new C_PongMessageObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class C_PongMessageObjectSegment<TTypeResolver> : global::Voxels.Networking.C_PongMessage, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 1 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;


        // 0
        public override byte CommandID
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public C_PongMessageObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 0, __elementSizes);

        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (0 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, byte>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 0);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class S_UpdateEntityMessageFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Networking.S_UpdateEntityMessage>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Networking.S_UpdateEntityMessage value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (1 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, byte>(ref bytes, startOffset, offset, 0, value.CommandID);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, uint>(ref bytes, startOffset, offset, 1, value.UID);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 1);
            }
        }

        public override global::Voxels.Networking.S_UpdateEntityMessage Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new S_UpdateEntityMessageObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class S_UpdateEntityMessageObjectSegment<TTypeResolver> : global::Voxels.Networking.S_UpdateEntityMessage, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 1, 4 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;


        // 0
        public override byte CommandID
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 1
        public override uint UID
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, uint>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, uint>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public S_UpdateEntityMessageObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 1, __elementSizes);

        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (1 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, byte>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, uint>(ref targetBytes, startOffset, offset, 1, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 1);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }


}

#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter.DynamicObjectSegments.Voxels
{
    using global::System;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;

    public class BlockDataHolderFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.BlockDataHolder>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.BlockDataHolder value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (3 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 0, value.SizeX);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 1, value.SizeY);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 2, value.SizeZ);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::Voxels.BlockData[]>(ref bytes, startOffset, offset, 3, value.Data);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 3);
            }
        }

        public override global::Voxels.BlockDataHolder Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new BlockDataHolderObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class BlockDataHolderObjectSegment<TTypeResolver> : global::Voxels.BlockDataHolder, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 4, 4, 4, 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, global::Voxels.BlockData[]> _Data;

        // 0
        public override int SizeX
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 1
        public override int SizeY
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 2
        public override int SizeZ
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 3
        public override global::Voxels.BlockData[] Data
        {
            get
            {
                return _Data.Value;
            }
            set
            {
                _Data.Value = value;
            }
        }


        public BlockDataHolderObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 3, __elementSizes);

            _Data = new CacheSegment<TTypeResolver, global::Voxels.BlockData[]>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 3, __binaryLastIndex, __tracker));
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (3 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 1, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 2, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::Voxels.BlockData[]>(ref targetBytes, startOffset, offset, 3, ref _Data);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 3);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class BlockDataArrayHintFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.BlockDataArrayHint>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.BlockDataArrayHint value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (0 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::Voxels.BlockData[,,]>(ref bytes, startOffset, offset, 0, value.Hint1);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 0);
            }
        }

        public override global::Voxels.BlockDataArrayHint Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new BlockDataArrayHintObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class BlockDataArrayHintObjectSegment<TTypeResolver> : global::Voxels.BlockDataArrayHint, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, global::Voxels.BlockData[,,]> _Hint1;

        // 0
        public override global::Voxels.BlockData[,,] Hint1
        {
            get
            {
                return _Hint1.Value;
            }
            set
            {
                _Hint1.Value = value;
            }
        }


        public BlockDataArrayHintObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 0, __elementSizes);

            _Hint1 = new CacheSegment<TTypeResolver, global::Voxels.BlockData[,,]>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 0, __binaryLastIndex, __tracker));
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (0 + 1));

                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::Voxels.BlockData[,,]>(ref targetBytes, startOffset, offset, 0, ref _Hint1);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 0);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class VisibilityFlagsArrayHintFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.VisibilityFlagsArrayHint>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.VisibilityFlagsArrayHint value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (0 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::Voxels.VisibilityFlags[,,]>(ref bytes, startOffset, offset, 0, value.Hint1);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 0);
            }
        }

        public override global::Voxels.VisibilityFlagsArrayHint Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new VisibilityFlagsArrayHintObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class VisibilityFlagsArrayHintObjectSegment<TTypeResolver> : global::Voxels.VisibilityFlagsArrayHint, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, global::Voxels.VisibilityFlags[,,]> _Hint1;

        // 0
        public override global::Voxels.VisibilityFlags[,,] Hint1
        {
            get
            {
                return _Hint1.Value;
            }
            set
            {
                _Hint1.Value = value;
            }
        }


        public VisibilityFlagsArrayHintObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 0, __elementSizes);

            _Hint1 = new CacheSegment<TTypeResolver, global::Voxels.VisibilityFlags[,,]>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 0, __binaryLastIndex, __tracker));
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (0 + 1));

                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::Voxels.VisibilityFlags[,,]>(ref targetBytes, startOffset, offset, 0, ref _Hint1);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 0);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class Int3HashsetHintFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Int3HashsetHint>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Int3HashsetHint value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (0 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::System.Collections.Generic.HashSet<global::Voxels.Int3>>(ref bytes, startOffset, offset, 0, value.Hint1);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 0);
            }
        }

        public override global::Voxels.Int3HashsetHint Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new Int3HashsetHintObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class Int3HashsetHintObjectSegment<TTypeResolver> : global::Voxels.Int3HashsetHint, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, global::System.Collections.Generic.HashSet<global::Voxels.Int3>> _Hint1;

        // 0
        public override global::System.Collections.Generic.HashSet<global::Voxels.Int3> Hint1
        {
            get
            {
                return _Hint1.Value;
            }
            set
            {
                _Hint1.Value = value;
            }
        }


        public Int3HashsetHintObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 0, __elementSizes);

            _Hint1 = new CacheSegment<TTypeResolver, global::System.Collections.Generic.HashSet<global::Voxels.Int3>>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 0, __binaryLastIndex, __tracker));
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (0 + 1));

                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::System.Collections.Generic.HashSet<global::Voxels.Int3>>(ref targetBytes, startOffset, offset, 0, ref _Hint1);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 0);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class VisibilityFlagsHolderFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.VisibilityFlagsHolder>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.VisibilityFlagsHolder value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (3 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 0, value.SizeX);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 1, value.SizeY);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 2, value.SizeZ);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::Voxels.VisibilityFlags[]>(ref bytes, startOffset, offset, 3, value.Data);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 3);
            }
        }

        public override global::Voxels.VisibilityFlagsHolder Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new VisibilityFlagsHolderObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class VisibilityFlagsHolderObjectSegment<TTypeResolver> : global::Voxels.VisibilityFlagsHolder, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 4, 4, 4, 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, global::Voxels.VisibilityFlags[]> _Data;

        // 0
        public override int SizeX
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 1
        public override int SizeY
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 2
        public override int SizeZ
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 3
        public override global::Voxels.VisibilityFlags[] Data
        {
            get
            {
                return _Data.Value;
            }
            set
            {
                _Data.Value = value;
            }
        }


        public VisibilityFlagsHolderObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 3, __elementSizes);

            _Data = new CacheSegment<TTypeResolver, global::Voxels.VisibilityFlags[]>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 3, __binaryLastIndex, __tracker));
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (3 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 1, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 2, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::Voxels.VisibilityFlags[]>(ref targetBytes, startOffset, offset, 3, ref _Data);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 3);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class ChunkDataFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.ChunkData>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.ChunkData value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (5 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 0, value.IndexX);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 1, value.IndexY);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 2, value.IndexZ);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 3, value.Height);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::UnityEngine.Vector3>(ref bytes, startOffset, offset, 4, value.Origin);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::Voxels.BlockDataHolder>(ref bytes, startOffset, offset, 5, value.Blocks);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 5);
            }
        }

        public override global::Voxels.ChunkData Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new ChunkDataObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class ChunkDataObjectSegment<TTypeResolver> : global::Voxels.ChunkData, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 4, 4, 4, 4, 0, 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, global::UnityEngine.Vector3> _Origin;
        global::Voxels.BlockDataHolder _Blocks;

        // 0
        public override int IndexX
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 1
        public override int IndexY
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 2
        public override int IndexZ
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 3
        public override int Height
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 4
        public override global::UnityEngine.Vector3 Origin
        {
            get
            {
                return _Origin.Value;
            }
            set
            {
                _Origin.Value = value;
            }
        }

        // 5
        public override global::Voxels.BlockDataHolder Blocks
        {
            get
            {
                return _Blocks;
            }
            set
            {
                __tracker.Dirty();
                _Blocks = value;
            }
        }


        public ChunkDataObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 5, __elementSizes);

            _Origin = new CacheSegment<TTypeResolver, global::UnityEngine.Vector3>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 4, __binaryLastIndex, __tracker));
            _Blocks = ObjectSegmentHelper.DeserializeSegment<TTypeResolver, global::Voxels.BlockDataHolder>(originalBytes, 5, __binaryLastIndex, __tracker);
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (5 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 1, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 2, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 3, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::UnityEngine.Vector3>(ref targetBytes, startOffset, offset, 4, ref _Origin);
                offset += ObjectSegmentHelper.SerializeSegment<TTypeResolver, global::Voxels.BlockDataHolder>(ref targetBytes, startOffset, offset, 5, _Blocks);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 5);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }


}

#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter.DynamicObjectSegments.Voxels.Networking.Serverside
{
    using global::System;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;

    public class WorldOptionsDataHolderFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Networking.Serverside.WorldOptionsDataHolder>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Networking.Serverside.WorldOptionsDataHolder value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (7 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 0, value.Seed);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 1, value.ChunkLoadRadius);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 2, value.MaxLoadRadius);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 3, value.ChunkUnloadDistance);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 4, value.UselessChunksMaxAge);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, float>(ref bytes, startOffset, offset, 5, value.DayLength);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, float>(ref bytes, startOffset, offset, 6, value.WorldTime);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, float>(ref bytes, startOffset, offset, 7, value.TimeMultiplier);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 7);
            }
        }

        public override global::Voxels.Networking.Serverside.WorldOptionsDataHolder Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new WorldOptionsDataHolderObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class WorldOptionsDataHolderObjectSegment<TTypeResolver> : global::Voxels.Networking.Serverside.WorldOptionsDataHolder, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 4, 4, 4, 4, 4, 4, 4, 4 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;


        // 0
        public override int Seed
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 1
        public override int ChunkLoadRadius
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 2
        public override int MaxLoadRadius
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 3
        public override int ChunkUnloadDistance
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 4
        public override int UselessChunksMaxAge
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 4, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 4, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 5
        public override float DayLength
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, float>(__originalBytes, 5, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, float>(__originalBytes, 5, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 6
        public override float WorldTime
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, float>(__originalBytes, 6, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, float>(__originalBytes, 6, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 7
        public override float TimeMultiplier
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, float>(__originalBytes, 7, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, float>(__originalBytes, 7, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public WorldOptionsDataHolderObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 7, __elementSizes);

        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (7 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 1, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 2, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 3, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 4, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, float>(ref targetBytes, startOffset, offset, 5, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, float>(ref targetBytes, startOffset, offset, 6, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, float>(ref targetBytes, startOffset, offset, 7, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 7);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class MainDataHolderFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Networking.Serverside.MainDataHolder>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Networking.Serverside.MainDataHolder value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (0 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::Voxels.Int3[]>(ref bytes, startOffset, offset, 0, value.ChunkArray);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 0);
            }
        }

        public override global::Voxels.Networking.Serverside.MainDataHolder Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new MainDataHolderObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class MainDataHolderObjectSegment<TTypeResolver> : global::Voxels.Networking.Serverside.MainDataHolder, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, global::Voxels.Int3[]> _ChunkArray;

        // 0
        public override global::Voxels.Int3[] ChunkArray
        {
            get
            {
                return _ChunkArray.Value;
            }
            set
            {
                _ChunkArray.Value = value;
            }
        }


        public MainDataHolderObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 0, __elementSizes);

            _ChunkArray = new CacheSegment<TTypeResolver, global::Voxels.Int3[]>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 0, __binaryLastIndex, __tracker));
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (0 + 1));

                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::Voxels.Int3[]>(ref targetBytes, startOffset, offset, 0, ref _ChunkArray);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 0);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }


}

#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter.DynamicObjectSegments.Voxels.Networking.Clientside.Entities
{
    using global::System;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;

    public class FlyingBlockClientStateFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Networking.Clientside.Entities.FlyingBlockClientState>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Networking.Clientside.Entities.FlyingBlockClientState value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (0 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::Voxels.BlockData>(ref bytes, startOffset, offset, 0, value.BlockData);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 0);
            }
        }

        public override global::Voxels.Networking.Clientside.Entities.FlyingBlockClientState Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new FlyingBlockClientStateObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class FlyingBlockClientStateObjectSegment<TTypeResolver> : global::Voxels.Networking.Clientside.Entities.FlyingBlockClientState, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, global::Voxels.BlockData> _BlockData;

        // 0
        public override global::Voxels.BlockData BlockData
        {
            get
            {
                return _BlockData.Value;
            }
            set
            {
                _BlockData.Value = value;
            }
        }


        public FlyingBlockClientStateObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 0, __elementSizes);

            _BlockData = new CacheSegment<TTypeResolver, global::Voxels.BlockData>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 0, __binaryLastIndex, __tracker));
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (0 + 1));

                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::Voxels.BlockData>(ref targetBytes, startOffset, offset, 0, ref _BlockData);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 0);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }


}

#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter.DynamicObjectSegments.Voxels.Networking.Serverside.Entities
{
    using global::System;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;

    public class FlyingBlockServerStateFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Networking.Serverside.Entities.FlyingBlockServerState>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Networking.Serverside.Entities.FlyingBlockServerState value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (4 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::Voxels.BlockData>(ref bytes, startOffset, offset, 0, value.Block);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, ushort>(ref bytes, startOffset, offset, 1, value.MaxAge);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, ushort>(ref bytes, startOffset, offset, 2, value.Age);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::UnityEngine.Vector3>(ref bytes, startOffset, offset, 3, value.MoveDirection);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::Voxels.Networking.Serverside.Entities.FlyingBlockContactBehaviour>(ref bytes, startOffset, offset, 4, value.ContactAction);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 4);
            }
        }

        public override global::Voxels.Networking.Serverside.Entities.FlyingBlockServerState Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new FlyingBlockServerStateObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class FlyingBlockServerStateObjectSegment<TTypeResolver> : global::Voxels.Networking.Serverside.Entities.FlyingBlockServerState, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 0, 2, 2, 0, 1 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, global::Voxels.BlockData> _Block;
        CacheSegment<TTypeResolver, global::UnityEngine.Vector3> _MoveDirection;

        // 0
        public override global::Voxels.BlockData Block
        {
            get
            {
                return _Block.Value;
            }
            set
            {
                _Block.Value = value;
            }
        }

        // 1
        public override ushort MaxAge
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, ushort>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, ushort>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 2
        public override ushort Age
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, ushort>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, ushort>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 3
        public override global::UnityEngine.Vector3 MoveDirection
        {
            get
            {
                return _MoveDirection.Value;
            }
            set
            {
                _MoveDirection.Value = value;
            }
        }

        // 4
        public override global::Voxels.Networking.Serverside.Entities.FlyingBlockContactBehaviour ContactAction
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, global::Voxels.Networking.Serverside.Entities.FlyingBlockContactBehaviour>(__originalBytes, 4, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, global::Voxels.Networking.Serverside.Entities.FlyingBlockContactBehaviour>(__originalBytes, 4, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public FlyingBlockServerStateObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 4, __elementSizes);

            _Block = new CacheSegment<TTypeResolver, global::Voxels.BlockData>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 0, __binaryLastIndex, __tracker));
            _MoveDirection = new CacheSegment<TTypeResolver, global::UnityEngine.Vector3>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 3, __binaryLastIndex, __tracker));
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (4 + 1));

                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::Voxels.BlockData>(ref targetBytes, startOffset, offset, 0, ref _Block);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, ushort>(ref targetBytes, startOffset, offset, 1, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, ushort>(ref targetBytes, startOffset, offset, 2, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::UnityEngine.Vector3>(ref targetBytes, startOffset, offset, 3, ref _MoveDirection);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, global::Voxels.Networking.Serverside.Entities.FlyingBlockContactBehaviour>(ref targetBytes, startOffset, offset, 4, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 4);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }


}

#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter.DynamicObjectSegments.Voxels
{
    using global::System;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;

    public class BlockDataFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.BlockData>
        where TTypeResolver : ITypeResolver, new()
    {
        readonly Formatter<TTypeResolver, global::Voxels.BlockType> formatter0;
        readonly Formatter<TTypeResolver, byte> formatter1;
        readonly Formatter<TTypeResolver, byte> formatter2;
        readonly Formatter<TTypeResolver, byte> formatter3;
        readonly Formatter<TTypeResolver, ushort> formatter4;
        readonly Formatter<TTypeResolver, ushort> formatter5;
        
        public override bool NoUseDirtyTracker
        {
            get
            {
                return formatter0.NoUseDirtyTracker
                    && formatter1.NoUseDirtyTracker
                    && formatter2.NoUseDirtyTracker
                    && formatter3.NoUseDirtyTracker
                    && formatter4.NoUseDirtyTracker
                    && formatter5.NoUseDirtyTracker
                ;
            }
        }

        public BlockDataFormatter()
        {
            formatter0 = Formatter<TTypeResolver, global::Voxels.BlockType>.Default;
            formatter1 = Formatter<TTypeResolver, byte>.Default;
            formatter2 = Formatter<TTypeResolver, byte>.Default;
            formatter3 = Formatter<TTypeResolver, byte>.Default;
            formatter4 = Formatter<TTypeResolver, ushort>.Default;
            formatter5 = Formatter<TTypeResolver, ushort>.Default;
            
        }

        public override int? GetLength()
        {
            return 8;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.BlockData value)
        {
            BinaryUtil.EnsureCapacity(ref bytes, offset, 8);
            var startOffset = offset;
            offset += formatter0.Serialize(ref bytes, offset, value.Type);
            offset += formatter1.Serialize(ref bytes, offset, value.Subtype);
            offset += formatter2.Serialize(ref bytes, offset, value.SunLevel);
            offset += formatter3.Serialize(ref bytes, offset, value.LightLevel);
            offset += formatter4.Serialize(ref bytes, offset, value.AddColor);
            offset += formatter5.Serialize(ref bytes, offset, value.Metadata);
            return offset - startOffset;
        }

        public override global::Voxels.BlockData Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 0;
            int size;
            var item0 = formatter0.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item1 = formatter1.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item2 = formatter2.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item3 = formatter3.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item4 = formatter4.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item5 = formatter5.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            
            return new global::Voxels.BlockData(item0, item1, item2, item3, item4, item5);
        }
    }

    public class Byte3Formatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Byte3>
        where TTypeResolver : ITypeResolver, new()
    {
        readonly Formatter<TTypeResolver, byte> formatter0;
        readonly Formatter<TTypeResolver, byte> formatter1;
        readonly Formatter<TTypeResolver, byte> formatter2;
        
        public override bool NoUseDirtyTracker
        {
            get
            {
                return formatter0.NoUseDirtyTracker
                    && formatter1.NoUseDirtyTracker
                    && formatter2.NoUseDirtyTracker
                ;
            }
        }

        public Byte3Formatter()
        {
            formatter0 = Formatter<TTypeResolver, byte>.Default;
            formatter1 = Formatter<TTypeResolver, byte>.Default;
            formatter2 = Formatter<TTypeResolver, byte>.Default;
            
        }

        public override int? GetLength()
        {
            return 3;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Byte3 value)
        {
            BinaryUtil.EnsureCapacity(ref bytes, offset, 3);
            var startOffset = offset;
            offset += formatter0.Serialize(ref bytes, offset, value.X);
            offset += formatter1.Serialize(ref bytes, offset, value.Y);
            offset += formatter2.Serialize(ref bytes, offset, value.Z);
            return offset - startOffset;
        }

        public override global::Voxels.Byte3 Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 0;
            int size;
            var item0 = formatter0.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item1 = formatter1.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item2 = formatter2.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            
            return new global::Voxels.Byte3(item0, item1, item2);
        }
    }

    public class Int3Formatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Int3>
        where TTypeResolver : ITypeResolver, new()
    {
        readonly Formatter<TTypeResolver, int> formatter0;
        readonly Formatter<TTypeResolver, int> formatter1;
        readonly Formatter<TTypeResolver, int> formatter2;
        
        public override bool NoUseDirtyTracker
        {
            get
            {
                return formatter0.NoUseDirtyTracker
                    && formatter1.NoUseDirtyTracker
                    && formatter2.NoUseDirtyTracker
                ;
            }
        }

        public Int3Formatter()
        {
            formatter0 = Formatter<TTypeResolver, int>.Default;
            formatter1 = Formatter<TTypeResolver, int>.Default;
            formatter2 = Formatter<TTypeResolver, int>.Default;
            
        }

        public override int? GetLength()
        {
            return 12;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Int3 value)
        {
            BinaryUtil.EnsureCapacity(ref bytes, offset, 12);
            var startOffset = offset;
            offset += formatter0.Serialize(ref bytes, offset, value.X);
            offset += formatter1.Serialize(ref bytes, offset, value.Y);
            offset += formatter2.Serialize(ref bytes, offset, value.Z);
            return offset - startOffset;
        }

        public override global::Voxels.Int3 Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 0;
            int size;
            var item0 = formatter0.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item1 = formatter1.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item2 = formatter2.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            
            return new global::Voxels.Int3(item0, item1, item2);
        }
    }


}

#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter.DynamicObjectSegments.UnityEngine
{
    using global::System;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;

    public class Vector3Formatter<TTypeResolver> : Formatter<TTypeResolver, global::UnityEngine.Vector3>
        where TTypeResolver : ITypeResolver, new()
    {
        readonly Formatter<TTypeResolver, float> formatter0;
        readonly Formatter<TTypeResolver, float> formatter1;
        readonly Formatter<TTypeResolver, float> formatter2;
        
        public override bool NoUseDirtyTracker
        {
            get
            {
                return formatter0.NoUseDirtyTracker
                    && formatter1.NoUseDirtyTracker
                    && formatter2.NoUseDirtyTracker
                ;
            }
        }

        public Vector3Formatter()
        {
            formatter0 = Formatter<TTypeResolver, float>.Default;
            formatter1 = Formatter<TTypeResolver, float>.Default;
            formatter2 = Formatter<TTypeResolver, float>.Default;
            
        }

        public override int? GetLength()
        {
            return 12;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::UnityEngine.Vector3 value)
        {
            BinaryUtil.EnsureCapacity(ref bytes, offset, 12);
            var startOffset = offset;
            offset += formatter0.Serialize(ref bytes, offset, value.x);
            offset += formatter1.Serialize(ref bytes, offset, value.y);
            offset += formatter2.Serialize(ref bytes, offset, value.z);
            return offset - startOffset;
        }

        public override global::UnityEngine.Vector3 Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 0;
            int size;
            var item0 = formatter0.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item1 = formatter1.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item2 = formatter2.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            
            return new global::UnityEngine.Vector3(item0, item1, item2);
        }
    }

    public class Vector2Formatter<TTypeResolver> : Formatter<TTypeResolver, global::UnityEngine.Vector2>
        where TTypeResolver : ITypeResolver, new()
    {
        readonly Formatter<TTypeResolver, float> formatter0;
        readonly Formatter<TTypeResolver, float> formatter1;
        
        public override bool NoUseDirtyTracker
        {
            get
            {
                return formatter0.NoUseDirtyTracker
                    && formatter1.NoUseDirtyTracker
                ;
            }
        }

        public Vector2Formatter()
        {
            formatter0 = Formatter<TTypeResolver, float>.Default;
            formatter1 = Formatter<TTypeResolver, float>.Default;
            
        }

        public override int? GetLength()
        {
            return 8;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::UnityEngine.Vector2 value)
        {
            BinaryUtil.EnsureCapacity(ref bytes, offset, 8);
            var startOffset = offset;
            offset += formatter0.Serialize(ref bytes, offset, value.x);
            offset += formatter1.Serialize(ref bytes, offset, value.y);
            return offset - startOffset;
        }

        public override global::UnityEngine.Vector2 Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 0;
            int size;
            var item0 = formatter0.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item1 = formatter1.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            
            return new global::UnityEngine.Vector2(item0, item1);
        }
    }


}

#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter.DynamicObjectSegments.DataStructures.ViliWonka.Tests
{
    using global::System;
    using global::System.Collections.Generic;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;


    public class QTypeFormatter<TTypeResolver> : Formatter<TTypeResolver, global::DataStructures.ViliWonka.Tests.QType>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::DataStructures.ViliWonka.Tests.QType value)
        {
            return BinaryUtil.WriteInt32(ref bytes, offset, (Int32)value);
        }

        public override global::DataStructures.ViliWonka.Tests.QType Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 4;
            return (global::DataStructures.ViliWonka.Tests.QType)BinaryUtil.ReadInt32(ref bytes, offset);
        }
    }


    public class NullableQTypeFormatter<TTypeResolver> : Formatter<TTypeResolver, global::DataStructures.ViliWonka.Tests.QType?>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 5;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::DataStructures.ViliWonka.Tests.QType? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteInt32(ref bytes, offset + 1, (Int32)value.Value);
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 5);
            }

            return 5;
        }

        public override global::DataStructures.ViliWonka.Tests.QType? Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 5;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::DataStructures.ViliWonka.Tests.QType)BinaryUtil.ReadInt32(ref bytes, offset + 1);
        }
    }



    public class QTypeEqualityComparer : IEqualityComparer<global::DataStructures.ViliWonka.Tests.QType>
    {
        public bool Equals(global::DataStructures.ViliWonka.Tests.QType x, global::DataStructures.ViliWonka.Tests.QType y)
        {
            return (Int32)x == (Int32)y;
        }

        public int GetHashCode(global::DataStructures.ViliWonka.Tests.QType x)
        {
            return (int)x;
        }
    }



}
#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter.DynamicObjectSegments.Voxels
{
    using global::System;
    using global::System.Collections.Generic;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;


    public class BlockMeshTypeFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.BlockMeshType>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 1;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.BlockMeshType value)
        {
            return BinaryUtil.WriteByte(ref bytes, offset, (Byte)value);
        }

        public override global::Voxels.BlockMeshType Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 1;
            return (global::Voxels.BlockMeshType)BinaryUtil.ReadByte(ref bytes, offset);
        }
    }


    public class NullableBlockMeshTypeFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.BlockMeshType?>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 2;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.BlockMeshType? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteByte(ref bytes, offset + 1, (Byte)value.Value);
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 2);
            }

            return 2;
        }

        public override global::Voxels.BlockMeshType? Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 2;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::Voxels.BlockMeshType)BinaryUtil.ReadByte(ref bytes, offset + 1);
        }
    }



    public class BlockMeshTypeEqualityComparer : IEqualityComparer<global::Voxels.BlockMeshType>
    {
        public bool Equals(global::Voxels.BlockMeshType x, global::Voxels.BlockMeshType y)
        {
            return (Byte)x == (Byte)y;
        }

        public int GetHashCode(global::Voxels.BlockMeshType x)
        {
            return (int)(Byte)x;
        }
    }



    public class DirIndexFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.DirIndex>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 1;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.DirIndex value)
        {
            return BinaryUtil.WriteByte(ref bytes, offset, (Byte)value);
        }

        public override global::Voxels.DirIndex Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 1;
            return (global::Voxels.DirIndex)BinaryUtil.ReadByte(ref bytes, offset);
        }
    }


    public class NullableDirIndexFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.DirIndex?>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 2;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.DirIndex? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteByte(ref bytes, offset + 1, (Byte)value.Value);
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 2);
            }

            return 2;
        }

        public override global::Voxels.DirIndex? Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 2;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::Voxels.DirIndex)BinaryUtil.ReadByte(ref bytes, offset + 1);
        }
    }



    public class DirIndexEqualityComparer : IEqualityComparer<global::Voxels.DirIndex>
    {
        public bool Equals(global::Voxels.DirIndex x, global::Voxels.DirIndex y)
        {
            return (Byte)x == (Byte)y;
        }

        public int GetHashCode(global::Voxels.DirIndex x)
        {
            return (int)(Byte)x;
        }
    }



    public class BlockTypeFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.BlockType>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 1;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.BlockType value)
        {
            return BinaryUtil.WriteByte(ref bytes, offset, (Byte)value);
        }

        public override global::Voxels.BlockType Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 1;
            return (global::Voxels.BlockType)BinaryUtil.ReadByte(ref bytes, offset);
        }
    }


    public class NullableBlockTypeFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.BlockType?>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 2;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.BlockType? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteByte(ref bytes, offset + 1, (Byte)value.Value);
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 2);
            }

            return 2;
        }

        public override global::Voxels.BlockType? Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 2;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::Voxels.BlockType)BinaryUtil.ReadByte(ref bytes, offset + 1);
        }
    }



    public class BlockTypeEqualityComparer : IEqualityComparer<global::Voxels.BlockType>
    {
        public bool Equals(global::Voxels.BlockType x, global::Voxels.BlockType y)
        {
            return (Byte)x == (Byte)y;
        }

        public int GetHashCode(global::Voxels.BlockType x)
        {
            return (int)(Byte)x;
        }
    }



    public class BlockModelTypeFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.BlockModelType>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 1;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.BlockModelType value)
        {
            return BinaryUtil.WriteByte(ref bytes, offset, (Byte)value);
        }

        public override global::Voxels.BlockModelType Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 1;
            return (global::Voxels.BlockModelType)BinaryUtil.ReadByte(ref bytes, offset);
        }
    }


    public class NullableBlockModelTypeFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.BlockModelType?>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 2;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.BlockModelType? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteByte(ref bytes, offset + 1, (Byte)value.Value);
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 2);
            }

            return 2;
        }

        public override global::Voxels.BlockModelType? Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 2;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::Voxels.BlockModelType)BinaryUtil.ReadByte(ref bytes, offset + 1);
        }
    }



    public class BlockModelTypeEqualityComparer : IEqualityComparer<global::Voxels.BlockModelType>
    {
        public bool Equals(global::Voxels.BlockModelType x, global::Voxels.BlockModelType y)
        {
            return (Byte)x == (Byte)y;
        }

        public int GetHashCode(global::Voxels.BlockModelType x)
        {
            return (int)(Byte)x;
        }
    }



    public class BlockHarvestLevelFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.BlockHarvestLevel>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 1;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.BlockHarvestLevel value)
        {
            return BinaryUtil.WriteByte(ref bytes, offset, (Byte)value);
        }

        public override global::Voxels.BlockHarvestLevel Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 1;
            return (global::Voxels.BlockHarvestLevel)BinaryUtil.ReadByte(ref bytes, offset);
        }
    }


    public class NullableBlockHarvestLevelFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.BlockHarvestLevel?>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 2;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.BlockHarvestLevel? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteByte(ref bytes, offset + 1, (Byte)value.Value);
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 2);
            }

            return 2;
        }

        public override global::Voxels.BlockHarvestLevel? Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 2;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::Voxels.BlockHarvestLevel)BinaryUtil.ReadByte(ref bytes, offset + 1);
        }
    }



    public class BlockHarvestLevelEqualityComparer : IEqualityComparer<global::Voxels.BlockHarvestLevel>
    {
        public bool Equals(global::Voxels.BlockHarvestLevel x, global::Voxels.BlockHarvestLevel y)
        {
            return (Byte)x == (Byte)y;
        }

        public int GetHashCode(global::Voxels.BlockHarvestLevel x)
        {
            return (int)(Byte)x;
        }
    }



    public class VisibilityFlagsFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.VisibilityFlags>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 1;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.VisibilityFlags value)
        {
            return BinaryUtil.WriteByte(ref bytes, offset, (Byte)value);
        }

        public override global::Voxels.VisibilityFlags Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 1;
            return (global::Voxels.VisibilityFlags)BinaryUtil.ReadByte(ref bytes, offset);
        }
    }


    public class NullableVisibilityFlagsFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.VisibilityFlags?>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 2;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.VisibilityFlags? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteByte(ref bytes, offset + 1, (Byte)value.Value);
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 2);
            }

            return 2;
        }

        public override global::Voxels.VisibilityFlags? Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 2;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::Voxels.VisibilityFlags)BinaryUtil.ReadByte(ref bytes, offset + 1);
        }
    }



    public class VisibilityFlagsEqualityComparer : IEqualityComparer<global::Voxels.VisibilityFlags>
    {
        public bool Equals(global::Voxels.VisibilityFlags x, global::Voxels.VisibilityFlags y)
        {
            return (Byte)x == (Byte)y;
        }

        public int GetHashCode(global::Voxels.VisibilityFlags x)
        {
            return (int)(Byte)x;
        }
    }



}
#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter.DynamicObjectSegments.Voxels.Networking
{
    using global::System;
    using global::System.Collections.Generic;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;


    public class PosUpdateOptionsFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Networking.PosUpdateOptions>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 1;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Networking.PosUpdateOptions value)
        {
            return BinaryUtil.WriteByte(ref bytes, offset, (Byte)value);
        }

        public override global::Voxels.Networking.PosUpdateOptions Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 1;
            return (global::Voxels.Networking.PosUpdateOptions)BinaryUtil.ReadByte(ref bytes, offset);
        }
    }


    public class NullablePosUpdateOptionsFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Networking.PosUpdateOptions?>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 2;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Networking.PosUpdateOptions? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteByte(ref bytes, offset + 1, (Byte)value.Value);
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 2);
            }

            return 2;
        }

        public override global::Voxels.Networking.PosUpdateOptions? Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 2;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::Voxels.Networking.PosUpdateOptions)BinaryUtil.ReadByte(ref bytes, offset + 1);
        }
    }



    public class PosUpdateOptionsEqualityComparer : IEqualityComparer<global::Voxels.Networking.PosUpdateOptions>
    {
        public bool Equals(global::Voxels.Networking.PosUpdateOptions x, global::Voxels.Networking.PosUpdateOptions y)
        {
            return (Byte)x == (Byte)y;
        }

        public int GetHashCode(global::Voxels.Networking.PosUpdateOptions x)
        {
            return (int)(Byte)x;
        }
    }



    public class PosUpdateTypeFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Networking.PosUpdateType>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 1;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Networking.PosUpdateType value)
        {
            return BinaryUtil.WriteByte(ref bytes, offset, (Byte)value);
        }

        public override global::Voxels.Networking.PosUpdateType Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 1;
            return (global::Voxels.Networking.PosUpdateType)BinaryUtil.ReadByte(ref bytes, offset);
        }
    }


    public class NullablePosUpdateTypeFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Networking.PosUpdateType?>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 2;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Networking.PosUpdateType? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteByte(ref bytes, offset + 1, (Byte)value.Value);
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 2);
            }

            return 2;
        }

        public override global::Voxels.Networking.PosUpdateType? Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 2;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::Voxels.Networking.PosUpdateType)BinaryUtil.ReadByte(ref bytes, offset + 1);
        }
    }



    public class PosUpdateTypeEqualityComparer : IEqualityComparer<global::Voxels.Networking.PosUpdateType>
    {
        public bool Equals(global::Voxels.Networking.PosUpdateType x, global::Voxels.Networking.PosUpdateType y)
        {
            return (Byte)x == (Byte)y;
        }

        public int GetHashCode(global::Voxels.Networking.PosUpdateType x)
        {
            return (int)(Byte)x;
        }
    }



    public class ServerPacketIDFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Networking.ServerPacketID>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 1;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Networking.ServerPacketID value)
        {
            return BinaryUtil.WriteByte(ref bytes, offset, (Byte)value);
        }

        public override global::Voxels.Networking.ServerPacketID Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 1;
            return (global::Voxels.Networking.ServerPacketID)BinaryUtil.ReadByte(ref bytes, offset);
        }
    }


    public class NullableServerPacketIDFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Networking.ServerPacketID?>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 2;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Networking.ServerPacketID? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteByte(ref bytes, offset + 1, (Byte)value.Value);
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 2);
            }

            return 2;
        }

        public override global::Voxels.Networking.ServerPacketID? Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 2;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::Voxels.Networking.ServerPacketID)BinaryUtil.ReadByte(ref bytes, offset + 1);
        }
    }



    public class ServerPacketIDEqualityComparer : IEqualityComparer<global::Voxels.Networking.ServerPacketID>
    {
        public bool Equals(global::Voxels.Networking.ServerPacketID x, global::Voxels.Networking.ServerPacketID y)
        {
            return (Byte)x == (Byte)y;
        }

        public int GetHashCode(global::Voxels.Networking.ServerPacketID x)
        {
            return (int)(Byte)x;
        }
    }



    public class ClientPacketIDFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Networking.ClientPacketID>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 1;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Networking.ClientPacketID value)
        {
            return BinaryUtil.WriteByte(ref bytes, offset, (Byte)value);
        }

        public override global::Voxels.Networking.ClientPacketID Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 1;
            return (global::Voxels.Networking.ClientPacketID)BinaryUtil.ReadByte(ref bytes, offset);
        }
    }


    public class NullableClientPacketIDFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Networking.ClientPacketID?>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 2;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Networking.ClientPacketID? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteByte(ref bytes, offset + 1, (Byte)value.Value);
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 2);
            }

            return 2;
        }

        public override global::Voxels.Networking.ClientPacketID? Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 2;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::Voxels.Networking.ClientPacketID)BinaryUtil.ReadByte(ref bytes, offset + 1);
        }
    }



    public class ClientPacketIDEqualityComparer : IEqualityComparer<global::Voxels.Networking.ClientPacketID>
    {
        public bool Equals(global::Voxels.Networking.ClientPacketID x, global::Voxels.Networking.ClientPacketID y)
        {
            return (Byte)x == (Byte)y;
        }

        public int GetHashCode(global::Voxels.Networking.ClientPacketID x)
        {
            return (int)(Byte)x;
        }
    }



    public class SStateFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Networking.SState>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 1;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Networking.SState value)
        {
            return BinaryUtil.WriteByte(ref bytes, offset, (Byte)value);
        }

        public override global::Voxels.Networking.SState Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 1;
            return (global::Voxels.Networking.SState)BinaryUtil.ReadByte(ref bytes, offset);
        }
    }


    public class NullableSStateFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Networking.SState?>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 2;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Networking.SState? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteByte(ref bytes, offset + 1, (Byte)value.Value);
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 2);
            }

            return 2;
        }

        public override global::Voxels.Networking.SState? Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 2;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::Voxels.Networking.SState)BinaryUtil.ReadByte(ref bytes, offset + 1);
        }
    }



    public class SStateEqualityComparer : IEqualityComparer<global::Voxels.Networking.SState>
    {
        public bool Equals(global::Voxels.Networking.SState x, global::Voxels.Networking.SState y)
        {
            return (Byte)x == (Byte)y;
        }

        public int GetHashCode(global::Voxels.Networking.SState x)
        {
            return (int)(Byte)x;
        }
    }



    public class PlayerActionTypeFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Networking.PlayerActionType>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 1;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Networking.PlayerActionType value)
        {
            return BinaryUtil.WriteByte(ref bytes, offset, (Byte)value);
        }

        public override global::Voxels.Networking.PlayerActionType Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 1;
            return (global::Voxels.Networking.PlayerActionType)BinaryUtil.ReadByte(ref bytes, offset);
        }
    }


    public class NullablePlayerActionTypeFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Networking.PlayerActionType?>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 2;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Networking.PlayerActionType? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteByte(ref bytes, offset + 1, (Byte)value.Value);
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 2);
            }

            return 2;
        }

        public override global::Voxels.Networking.PlayerActionType? Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 2;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::Voxels.Networking.PlayerActionType)BinaryUtil.ReadByte(ref bytes, offset + 1);
        }
    }



    public class PlayerActionTypeEqualityComparer : IEqualityComparer<global::Voxels.Networking.PlayerActionType>
    {
        public bool Equals(global::Voxels.Networking.PlayerActionType x, global::Voxels.Networking.PlayerActionType y)
        {
            return (Byte)x == (Byte)y;
        }

        public int GetHashCode(global::Voxels.Networking.PlayerActionType x)
        {
            return (int)(Byte)x;
        }
    }



    public class ChatMessageTypeFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Networking.ChatMessageType>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 1;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Networking.ChatMessageType value)
        {
            return BinaryUtil.WriteByte(ref bytes, offset, (Byte)value);
        }

        public override global::Voxels.Networking.ChatMessageType Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 1;
            return (global::Voxels.Networking.ChatMessageType)BinaryUtil.ReadByte(ref bytes, offset);
        }
    }


    public class NullableChatMessageTypeFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Networking.ChatMessageType?>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 2;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Networking.ChatMessageType? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteByte(ref bytes, offset + 1, (Byte)value.Value);
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 2);
            }

            return 2;
        }

        public override global::Voxels.Networking.ChatMessageType? Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 2;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::Voxels.Networking.ChatMessageType)BinaryUtil.ReadByte(ref bytes, offset + 1);
        }
    }



    public class ChatMessageTypeEqualityComparer : IEqualityComparer<global::Voxels.Networking.ChatMessageType>
    {
        public bool Equals(global::Voxels.Networking.ChatMessageType x, global::Voxels.Networking.ChatMessageType y)
        {
            return (Byte)x == (Byte)y;
        }

        public int GetHashCode(global::Voxels.Networking.ChatMessageType x)
        {
            return (int)(Byte)x;
        }
    }



}
#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter.DynamicObjectSegments.Voxels.Networking.Serverside
{
    using global::System;
    using global::System.Collections.Generic;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;


    public class CStateFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Networking.Serverside.CState>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 1;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Networking.Serverside.CState value)
        {
            return BinaryUtil.WriteByte(ref bytes, offset, (Byte)value);
        }

        public override global::Voxels.Networking.Serverside.CState Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 1;
            return (global::Voxels.Networking.Serverside.CState)BinaryUtil.ReadByte(ref bytes, offset);
        }
    }


    public class NullableCStateFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Networking.Serverside.CState?>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 2;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Networking.Serverside.CState? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteByte(ref bytes, offset + 1, (Byte)value.Value);
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 2);
            }

            return 2;
        }

        public override global::Voxels.Networking.Serverside.CState? Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 2;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::Voxels.Networking.Serverside.CState)BinaryUtil.ReadByte(ref bytes, offset + 1);
        }
    }



    public class CStateEqualityComparer : IEqualityComparer<global::Voxels.Networking.Serverside.CState>
    {
        public bool Equals(global::Voxels.Networking.Serverside.CState x, global::Voxels.Networking.Serverside.CState y)
        {
            return (Byte)x == (Byte)y;
        }

        public int GetHashCode(global::Voxels.Networking.Serverside.CState x)
        {
            return (int)(Byte)x;
        }
    }



}
#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter.DynamicObjectSegments.Voxels.Networking.Serverside.Entities
{
    using global::System;
    using global::System.Collections.Generic;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;


    public class FlyingBlockContactBehaviourFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Networking.Serverside.Entities.FlyingBlockContactBehaviour>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 1;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Networking.Serverside.Entities.FlyingBlockContactBehaviour value)
        {
            return BinaryUtil.WriteByte(ref bytes, offset, (Byte)value);
        }

        public override global::Voxels.Networking.Serverside.Entities.FlyingBlockContactBehaviour Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 1;
            return (global::Voxels.Networking.Serverside.Entities.FlyingBlockContactBehaviour)BinaryUtil.ReadByte(ref bytes, offset);
        }
    }


    public class NullableFlyingBlockContactBehaviourFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Networking.Serverside.Entities.FlyingBlockContactBehaviour?>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 2;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Networking.Serverside.Entities.FlyingBlockContactBehaviour? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteByte(ref bytes, offset + 1, (Byte)value.Value);
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 2);
            }

            return 2;
        }

        public override global::Voxels.Networking.Serverside.Entities.FlyingBlockContactBehaviour? Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 2;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::Voxels.Networking.Serverside.Entities.FlyingBlockContactBehaviour)BinaryUtil.ReadByte(ref bytes, offset + 1);
        }
    }



    public class FlyingBlockContactBehaviourEqualityComparer : IEqualityComparer<global::Voxels.Networking.Serverside.Entities.FlyingBlockContactBehaviour>
    {
        public bool Equals(global::Voxels.Networking.Serverside.Entities.FlyingBlockContactBehaviour x, global::Voxels.Networking.Serverside.Entities.FlyingBlockContactBehaviour y)
        {
            return (Byte)x == (Byte)y;
        }

        public int GetHashCode(global::Voxels.Networking.Serverside.Entities.FlyingBlockContactBehaviour x)
        {
            return (int)(Byte)x;
        }
    }



}
#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
