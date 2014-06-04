﻿using UnityEngine;
using System.Collections;
using System;

public class ImageBubble : MonoBehaviour {

	public int offset = 1;
	public int divider = 10;

	private VisualizerManager visManager;
	// Use this for initialization
	void Start () {
		this.visManager = gameObject.GetComponent<VisualizerManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		var currentVis = this.visManager.visualizations [visManager.currentlySelectedVis];
		foreach (var imageItem in currentVis.targetMetadataParser.output) {
			try
			{
			var distance = Vector3.Distance(imageItem.transform.position,gameObject.transform.position);
			var opacity = distance/divider -offset;
			imageItem.material.color = new Color(1.0f, 1.0f, 1.0f,opacity);
			} catch (NullReferenceException e)
			{
				/* FIXME : should handle parser item swithout quads (ie. priority *)
				 * better than this. */
			}
		}
	}
}
